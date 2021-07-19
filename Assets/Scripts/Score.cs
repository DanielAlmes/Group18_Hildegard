using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] public Text scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    //this is called by objects that influence the score
    //it works as follows:
    //FindObjectOfType<Countdown>().addTime(float);
    public void AddScore(int scoreToAdd)
    {
        this.score += scoreToAdd;
    }

    public int GetScore()
    {
        return score;
    }
}
