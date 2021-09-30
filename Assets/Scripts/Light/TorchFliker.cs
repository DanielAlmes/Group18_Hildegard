using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFliker : MonoBehaviour
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

    // Playing different Light Animations to animate the Torch flicker
    IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1, 4);
        if (lightMode == 1)
        {
            flameLight.GetComponent<Animation>().Play("TorchAnim001");
        }
        if (lightMode == 2)
        {
            flameLight.GetComponent<Animation>().Play("TorchAnim002");
        }
        if (lightMode == 3)
        {
            flameLight.GetComponent<Animation>().Play("TorchAnim003");
        }

        yield return new WaitForSeconds(0.99f);
        lightMode = 0;
    }
}
