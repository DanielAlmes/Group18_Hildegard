using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorOpen : MonoBehaviour
{
    public float _distance;

    public GameObject ActionText;
    public GameObject Door;
    public AudioSource CreakSound;
    
    // Update is called once per frame
    void Update()
    {
        _distance = PlayerCasting.DistanceFromTarget;

    }

    private void OnMouseOver()
    {
        if (_distance <= 2f)
        {
            ActionText.GetComponent<Text>().text = "A closed door.";
            ActionText.SetActive(true);
            Cursor.visible = true;
            }
        else
        {
            ActionText.SetActive(false);
            Cursor.visible = false;
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_distance <= 2f)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false);
                Door.GetComponent<Animation>().Play("DoorOpenAnim001");
                CreakSound.Play();
                Cursor.visible = false;
            }
        }
    }

    private void OnMouseExit()
    {
        ActionText.SetActive(false);
        Cursor.visible = false;
    }
}
