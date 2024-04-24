using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int currentScore = 0;
    [SerializeField] Text scoreText;

    void Start()
    {
        // Initialize the score text
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // Method to increase the score
    public void IncreaseScore()
    {
        currentScore++;
        UpdateScoreText(); 
    }
}
