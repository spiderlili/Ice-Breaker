using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1.0f;
    [SerializeField] int scorePerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    //state variables
    [SerializeField] int currentScore = 0;

    void Start () {
        scoreText.text = "Score: " + currentScore.ToString();
	}

    //speed needs to be known for every single frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddToScore() {
        currentScore += scorePerBlockDestroyed;
        scoreText.text = "Score: " + currentScore.ToString(); 
    }
}
