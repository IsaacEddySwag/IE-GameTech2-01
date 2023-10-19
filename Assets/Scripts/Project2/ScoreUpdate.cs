using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TMP_Text myText;
    public int score = 0;
    public int totalScore = 0;
    private int scoreToAdd = 20;

    //Sets the text for score equal to the score variable and sets the initial amount of score added upon enemy death
    void Start()
    {
        myText.SetText(score.ToString());
        scoreToAdd = 20;
    }


    //Updates the text in the UI to be equal to score, this updates the score on screen if it ever changes
    void Update()
    {
        myText.SetText(score.ToString());
    }

    //Adds score the the score count
    public void AddScore()
    {
        //Score is changed via the scoreToAdd variable which changes based on player upgrades
        score += scoreToAdd;
        //total score which is used to increase enemy spawn rates stays at 20 per enemy killed to not overwhelm the players who upgrade their score amount
        totalScore += 20;
    }

    //Increases amount of score got when enemies are killed by 20 per invoke
    public void ScoreMultiply()
    {
        scoreToAdd += 20;
    }
}
