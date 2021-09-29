using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fadeOutScreen;
    [SerializeField] private GameObject textBox;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.visible = false;
            player.GetComponent<PlayerController>().enabled = false;
            StartCoroutine(ScenePlayer());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
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
