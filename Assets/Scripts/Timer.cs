using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Timer : MonoBehaviour
{
    [SerializeField] 
    public Text timeText;
    [SerializeField] 
    public float timeLeft = 30;
    //necessary so time over is only executed once
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeLeft > 0)
            {
                //substract passed time
                timeLeft -= Time.deltaTime;
                //display time in textfield
                DisplayTime(timeLeft);
            }
            else
            {
                //necessary because time gets substracted in chunks
                timeLeft = 0;
                timerIsRunning = false;
                //loads game over screen
                //call the function "GameOver()" in the object "GameManager"
                GameObject.Find("GameManager").GetComponent<EndGame>().GameOver();
            }
        }

        void DisplayTime(float timeToDisplay)
        {
            //calculate minutes
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            //calculate seconds
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    
    //function called from other objects that are supposed to add/substract time
    //for this use:
    // in start: GameObject countdown = FindObjectOfType<Countdown>();
    // in update countdown.addTime(float);
    public void AddTime(float timeToAdd)
    {
        this.timeLeft += timeToAdd;
    }
}
