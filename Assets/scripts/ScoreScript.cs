using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString(); 
    }
    
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }
}
