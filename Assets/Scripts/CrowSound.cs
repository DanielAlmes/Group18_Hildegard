using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowSound : MonoBehaviour
{
    public AudioSource CreakSound;
    public void OnTriggerEnter(Collider other)
    {
        
        CreakSound.Play ();

    }
}
