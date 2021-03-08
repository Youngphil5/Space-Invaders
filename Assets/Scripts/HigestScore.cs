using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HigestScore : MonoBehaviour
{
    [SerializeField] private Text HighestScoreText;
    public static int HighestScore;
    private void Awake()
    {
        //PlayerPrefs.DeleteKey("HighestScore");
        HighestScore = PlayerPrefs.GetInt("HighestScore");
        postHighScore();
    }

    void postHighScore()
    {
        if (HighestScore < 10)
        {
            HighestScoreText.text = $"Highest-Score: 000{PlayerPrefs.GetInt("HighestScore")}";
        }
        else if (HighestScore >= 10 && HighestScore < 100)
        {
            HighestScoreText.text = $"Highest-Score: 00{PlayerPrefs.GetInt("HighestScore")}";
        }
        else if (HighestScore >= 100 && HighestScore < 1000)
        {
            HighestScoreText.text = $"Highest-Score: 0{PlayerPrefs.GetInt("HighestScore")}";
        }
        else
        {
            HighestScoreText.text = $"Highest-Score: {PlayerPrefs.GetInt("HighestScore")}";
        }
    }


    void Update()
    {
        if (Points.points > PlayerPrefs.GetInt("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", Points.points);
        }
    }
}
