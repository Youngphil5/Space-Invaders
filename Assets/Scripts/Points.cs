using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] private Text pointText;
    public static int points;
    public void awardPoint(String gameTag)
    {
        switch (gameTag)
        {
            case "EnemyType1" :
                points += 10;
                postPoints();
                break;
            case "EnemyType2" :
                points += 20;
                postPoints();
                break;
            case "EnemyType3" :
                points += 30;
                postPoints();
                break;
            case "EnemyType4" :
                points += 40;
                postPoints();
                break;
            default:
                break;
            
        }
    }

    void postPoints()
    {
        if (points < 10)
        {
            pointText.text = $"Points: 000{points}";
        }
        else if (points >= 10 && points < 100)
        {
            pointText.text = $"Points: 00{points}";
        }
        else if (points >= 100 && points < 1000)
        {
            pointText.text = $"Points: 0{points}";
        }
        else
        {
            pointText.text = $"Points: {points}";
        }
    }
    
    void Start()
    {
        points = 0;
        pointText.text = $"Points: 000{points}"; 
    }

    void Update()
    {
        postPoints();
    }
}
