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
        if (_distance <= 3f)
        {
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (_distance <= 3f)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false);
                Door.GetComponent<Animation>().Play("DoorOpenAnim");
                CreakSound.Play();
            }
        }
    }

    private void OnMouseExit()
    {
        ActionText.SetActive(false);
    }
}
