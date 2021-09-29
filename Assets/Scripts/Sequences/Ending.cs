using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fadeOutScreen;
    [SerializeField] private GameObject textBox;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        player.GetComponent<PlayerController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1f);
        textBox.GetComponent<Text>().text = "That is the exit!";
        yield return new WaitForSeconds(2f);
        fadeOutScreen.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
    }
}
