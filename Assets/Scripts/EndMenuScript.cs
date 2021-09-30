using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuScript : MonoBehaviour
{
    public void PlayAgainButton()
    {
        //reload the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        //load main menu 
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        //quit does only work in built, so we need this
        Debug.Log("Quit");
        //quit application
        Application.Quit();
    }
}
