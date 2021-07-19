using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    public GameObject MainMenu;

    [SerializeField]
    public GameObject OptionsMenu;
    
    
    void Start()
    {
        MainMenuButton();
        OptionsMenu.SetActive(false);
        //Instructions.SetActive(false)
    }
    
    public void MainMenuButton()
    {
        //deactivate MainMenu
        MainMenu.SetActive(true);
        //activate credits
        OptionsMenu.SetActive(false);
    }

    public void StartButton()
    {
        //loads the scene called "FirstScene"
        SceneManager.LoadScene("FistScene");
    }

    
    /*
     
     public void CreditsButton()
    {
        //deactivate the main menu
        MainMenu.SetActive(false);
        //activate the credits
        CreditsMenu.SetActive(true);
    }
    
    public void InstructionsButton()
    {
        MainMenu.SetActive(false);
        Instructions.SetActive(true);
    }
    
    public void HighscoreButton()
    {
        //StaticVar.scoreSave = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    */
    
    public void BackButton()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    
    public void OptionsButton()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    
    public void QuitButton()
    {
        //quitting the game only works in built
        Debug.Log("Quit");
        //Quit the game
        Application.Quit();
    }
}

