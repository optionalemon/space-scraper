using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro; 


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;  
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText; 

    private bool hasWon = false; 
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateScoreUI();
        winText.gameObject.SetActive(false);  
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
        Debug.Log("Current Score: " + score);  
        if (score >= 100 && !hasWon) 
        {
            WinGame();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    private void WinGame()
    {
        hasWon = true;  
        winText.gameObject.SetActive(true);  
        Debug.Log("You Win!"); 
    }
}

