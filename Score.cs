using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    private Player playerCode;
    
    public bool showText = false;
    public bool showDead = false;

    public Text scoreText;
    public Text limitScoreText;
    
    public Text deadScoreText;

    private int score = 0;
    private string limitScore;
    
    private int deadScore = 0;
    
    
    void Start()
    {
        playerCode = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        instance = this;
        
        scoreText.text = score.ToString() + " : SmartPoints";
        
        limitScoreText.text = limitScore.ToString();

        deadScoreText.gameObject.SetActive(false);

        //deadScoreText.text = "You are dead = " + deadScore.ToString() + " Time";
    }
    
    void Update()
    {
        if (showText == true)
        {
            scoreText.enabled = true;
            limitScoreText.enabled = true;  
        }
        else if(showText == false)
        {
            scoreText.enabled = false;
            limitScoreText.enabled = false;
        }

        if (score <= 3 && score >= 2)
        {
            limitScoreText.text = "Normal AI";
        }
        else if (score <= 7 && score >= 4)
        {
            limitScoreText.text = "Smart AI";
        }
        else if (score <= 11 && score >= 8)
        {
            limitScoreText.text = "That what we Looking for";
        }

        if (score >= 1)
        { 
            showText = true;
        }

        if (showDead == true)
        {
            deadScoreText.gameObject.SetActive(true);
        }
    }
    
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " : SmartPoints";
        limitScoreText.text = limitScore.ToString();
        Debug.Log("GG");
    }

    public void AddDead()
    {
        deadScore += 1;
        deadScoreText.text = "You are dead = " + deadScore.ToString() + " Time That A LOT ";
        Debug.Log("DD");
    }

    public void ShowDead()
    {
        showDead = true;
    }
}


