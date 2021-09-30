using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorOpeningAlone : MonoBehaviour
{
    public GameObject ActionText;
    public GameObject Door;
    public AudioSource CreakSound;
    public AudioSource SlamSound;
    
    //Open the door by itself on entering the trigger
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                    ActionText.SetActive(false);
                    Door.GetComponent<Animation>().Play("DoorOpenAnim001");
                    CreakSound.Play();
                    Cursor.visible = false;
        }

    }
    
    public void OnTriggerExit(Collider other)
    {
                ActionText.SetActive(false);
                Door.GetComponent<Animation>().Play("DoorSlamCloseAnim001");
                SlamSound.Play();
                Cursor.visible = false;

    }
}

