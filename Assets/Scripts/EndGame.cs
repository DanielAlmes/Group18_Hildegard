using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void GameOver()
    {
        //save score
        StaticVar.scoreSave = FindObjectOfType<Score>().GetScore();
        //load the highscore scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
