using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fadeInScreen;
    [SerializeField] private GameObject textBox;
    
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerController>().enabled = false;
        Cursor.visible = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1f);
        fadeInScreen.SetActive(false);
        textBox.GetComponent<Text>().text = "I have to get out of here!";
        yield return new WaitForSeconds(2f);
        textBox.GetComponent<Text>().text = "";
        player.GetComponent<PlayerController>().enabled = true;
    }
}
