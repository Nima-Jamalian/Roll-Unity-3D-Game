/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Script : MonoBehaviour
{
    public int score;
    //public int highscore;
    public Text scoreDisplay;
    //public Text highscoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        //changing score to string and display it
        scoreDisplay.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //check to see if the player has collided with gold
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            score++;
            Debug.Log(score);
        }
    }
}

*/
