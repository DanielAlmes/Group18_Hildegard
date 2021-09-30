using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HighscoreMenu : MonoBehaviour
{
    //[SerializeField]
    //public TextField textfield;

    public InputField inputField;
    private string playerName;
    
    
    public void MainMenuButton()
    {
        //load main menu
        SceneManager.LoadScene(0);
    }

    public void ResetHighscore()
    {
        //delete the player prefs
        PlayerPrefs.DeleteAll();
        //load highscore
        Highscore.LoadScores();
        //reload scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    

    public void QuitButton()
    {
        //quit the application
        Debug.Log("Quit");
        Application.Quit();
    }

    public void EnterButton()
    {
        playerName = inputField.text;
        //save new score and name
        Highscore.Record(playerName, StaticVar.scoreSave);
        //set score to 0, so we do not get stuck in a loop of adding the highscore
        StaticVar.scoreSave = 0;
        //reload scene to display changes
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
