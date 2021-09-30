using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public int lightMode;
    public GameObject flameLight;
    
    void Update()
    {
        if (lightMode == 0)
        {
            StartCoroutine(AnimateLight());
        }
    }

    // Playing different FlashLight Animations to animate the Light
    IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1, 4);
        if (lightMode == 1)
        {
            flameLight.GetComponent<Animation>().Play("FlashLight001");
        }
        if (lightMode == 2)
        {
            flameLight.GetComponent<Animation>().Play("FlashLight002");
        }
        if (lightMode == 3)
        {
            flameLight.GetComponent<Animation>().Play("FlashLight003");
        }

        yield return new WaitForSeconds(0.99f);
        lightMode = 0;
    }
}
