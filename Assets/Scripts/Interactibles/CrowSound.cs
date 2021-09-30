using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowSound : MonoBehaviour
{
    public AudioSource CawSound;
    // Play the crowsound upon entering
    public void OnTriggerEnter(Collider other)
    {
        
        CawSound.Play ();

    }
}
