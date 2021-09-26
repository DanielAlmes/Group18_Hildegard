using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] private float mouseSensitivity = 3.5f;
    [SerializeField] private float movementSensitivity = 2f;
    [SerializeField] private float speed = 6.0f;
    [SerializeField] [Range(0.0f, 0.5f)] private float movementSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] private float mouseSmoothTime = 0.03f;
    //Gravity
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.0f;
    
    [SerializeField] private bool lockCursor = true;

    private float _cameraPitch = 0.0f;
    private float _velocityY = 0.0f;
    private Vector2 _currentDir = Vector2.zero;
    private Vector2 _currentDirVelocity = Vector2.zero;
    private Vector2 _currentMouseDelta = Vector2.zero;
    private Vector2 _currentMouseDeltaVelocity = Vector2.zero;


    
    private CharacterController _controller = null;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vision();
        Movement();
    }

    // camera/head movement system via Mouse
    void Vision()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta,targetMouseDelta, ref _currentMouseDeltaVelocity, mouseSmoothTime);
        // vertical mouse movement - pivot camera on y-axis
        _cameraPitch -= _currentMouseDelta.y * mouseSensitivity;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -90.0f, 90.0f);
        playerCamera.localEulerAngles = Vector3.right * _cameraPitch;
        
        // horizontal mouse movement - pivot parent of camera on x-axis
        transform.Rotate(Vector3.up * (_currentMouseDelta.x * mouseSensitivity));
    }
    
    // movement on the plane
    void Movement()
    {
        // get current position
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();
        
        // smoothing the movement
        _currentDir = Vector2.SmoothDamp(_currentDir, targetDir, ref _currentDirVelocity, movementSmoothTime);
       
        // movement
        Vector3 velocity = (transform.forward * _currentDir.y + transform.right * _currentDir.x) * speed + Vector3.up * _velocityY;
        _controller.Move(velocity * Time.deltaTime);
       
        // horizontal ( left right)  movement - pivot camera on x-axis
        transform.Rotate(Vector3.up * (_currentDir.x * movementSensitivity));
       
        // jumping
        if (_controller.isGrounded)
        {
            _velocityY = 0.0f;
        }
        if (Input.GetButtonDown("Jump") && _controller.isGrounded)
        {
            _velocityY = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        // Gravity
        _velocityY += gravity * Time.deltaTime;
        
        // Sound : check if movement happens
        bool hasHorizontalInput = !Mathf.Approximately (Input.GetAxis("Horizontal"), 0f);
        bool hasVerticalInput = !Mathf.Approximately (Input.GetAxis("Vertical"), 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        if (isWalking)
        {
            if(!_audioSource.isPlaying)
            {
                _audioSource.Play ();

            }
        }
        else
        {
            _audioSource.Stop();
        }
    }


}
