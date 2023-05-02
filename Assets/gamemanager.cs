using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gamemanager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI HighscoreText;
    private int score;


    void Start()
    {
        UpdateScore(0);
        UpdateHighScore();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        CheckHighScore();
    }

    void CheckHighScore()
    {
        if(score > PlayerPrefs.GetInt("High Score",0))
        {
            PlayerPrefs.SetInt("High Score", score);
            UpdateHighScore();
        }
    }

    void UpdateHighScore()
    {
        HighscoreText.text = $"Highscore: {PlayerPrefs.GetInt("High Score", 0)}" ;
    }
}
