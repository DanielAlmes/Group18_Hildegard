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
    public AudioSource RattleSound;
    public bool _doorLockd;
    [SerializeField] private GameObject Key;
    void Update()
    {
    // get the distance to the door
        _distance = PlayerCasting.DistanceFromTarget;

    }

   // The mouse is on the door
    private void OnMouseOver()
    {
        // close to the door information and the cursor appear
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
        // opening the mouse by clicking onto it
        if (Input.GetMouseButtonDown(0))
        {
            if (_distance <= 2f)
            {
                if (_doorLockd == false)
                {
                    this.GetComponent<BoxCollider>().enabled = false; 
                    ActionText.SetActive(false);
                    Door.GetComponent<Animation>().Play("DoorOpenAnim001");
                    CreakSound.Play();
                    Cursor.visible = false;
                }

                if (_doorLockd == true)
                {
                    if (Key.activeSelf == false)
                    {
                        Door.GetComponent<Animation>().Play("RattlingDoorAnim001");
                        RattleSound.Play();
                        ActionText.GetComponent<Text>().text = "I need a key."; 
                        ActionText.SetActive(true);
                        Cursor.visible = true;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false; 
                        ActionText.SetActive(false);
                        Door.GetComponent<Animation>().Play("DoorOpenAnim001");
                        CreakSound.Play();
                        Cursor.visible = false;
                    }
                }
                
            }
        }
    }

    // The mouse leaves the door : Cursor and Information disappear
    private void OnMouseExit()
    {
        ActionText.SetActive(false);
        Cursor.visible = false;
    }
}
