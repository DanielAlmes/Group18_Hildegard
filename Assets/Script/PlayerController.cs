﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] private float mouseSensitivity = 3.5f;
    [SerializeField] private float movementSensitivity = 2f;
    [SerializeField] private float movementSpeed = 6.0f;
    [SerializeField] [Range(0.0f, 0.5f)] private float movementSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] private float mouseSmoothTime = 0.03f;
    [SerializeField] private float gravity = -13.0f;
    
    [SerializeField] private bool lockCursor = true;

    private float _cameraPitch = 0.0f;
    private float _velocityY = 0.0f;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    
    private CharacterController controller = null;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVision();
        UpdateMovement();
    }

    // camera/head movement system via Mouse
    void UpdateVision()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta,targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        // vertical mouse movement - pivot camera on y-axis
        _cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -90.0f, 90.0f);
        playerCamera.localEulerAngles = Vector3.right * _cameraPitch;
        
        // horizontal mouse movement - pivot parent of camera on x-axis
        transform.Rotate(Vector3.up * (currentMouseDelta.x * mouseSensitivity));
    }
    // movement on the plane
    void UpdateMovement()
    {
        // get current position
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();
        // smoothing the movement
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, movementSmoothTime);
        // Gravity
        if (controller.isGrounded)
        {
            _velocityY = 0.0f;
        }
        _velocityY += gravity * Time.deltaTime;
        
        // movement
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * movementSpeed + Vector3.up * _velocityY;
        controller.Move(velocity * Time.deltaTime);
       
        // horizontal ( left right)  movement - pivot camera on x-axis
        transform.Rotate(Vector3.up * (currentDir.x * movementSensitivity));
    }
}
