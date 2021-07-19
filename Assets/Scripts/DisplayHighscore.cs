using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    public InputField input;
    //private string name;

    public GameObject gameObject;

    void Start()
    {
        //hide the button and inputfield to enter name
        //if there is no new highscore
        if (!Highscore.CheckScore(StaticVar.scoreSave))
        {
            gameObject.SetActive(false);
        }

        //reload highscore when scene is loaded
        Highscore.LoadScores();
    }


    private void OnGUI() {
        //Creating the area that we can use (the screen)
        GUILayout.BeginArea(new Rect(Screen.width/10, Screen.height/7, Screen.width, Screen.height));
     
        //change font size
        GUIStyle headStyle = new GUIStyle();
        headStyle.fontSize = 15;
        
        // Display highscores!
        for (int i = 0; i < Highscore.EntryCount; ++i) {
            //retrive score and name for every entry
            var entry = Highscore.GetEntry(i);
            //create labels with entries
            GUILayout.Label(  entry.name + ", Score: " + entry.score, headStyle);
        }
        //space between layout group
        GUILayout.Space(10);
        
        GUILayout.EndArea();
    }

    

}
