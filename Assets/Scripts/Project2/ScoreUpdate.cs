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


    // Use this for initialization
    void Start()
    {
        myText.SetText(score.ToString());
    }


    // Update is called once per frame
    void Update()
    {
        myText.SetText(score.ToString());
    }
    public void AddScore()
    {
        score += 20;
        totalScore += 20;
    }
}
