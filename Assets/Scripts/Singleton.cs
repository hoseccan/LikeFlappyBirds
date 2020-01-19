using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Singleton : MonoBehaviour
{
    public int  score = 0;

    public Text       scoreText;
    public GameObject gameOverScreen;
    public GameObject gameScreen;

    public Text CurrentScor;
    public Text BiggestScore;

    public void OnEnable()
    {
        ResetLevel();
    }

    public void ResetLevel()
    {
        Time.timeScale            = 1;
        score                     = 0;
        UpdateScore();

        Transform playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        playerTransform.position  = new Vector3(-1.3f, 0, 0);

        Tube[] tubes = FindObjectsOfType<Tube>();
        foreach (Tube tube in tubes)
        {
            DestroyImmediate(tube.gameObject);
        }

        FindObjectOfType<TubesSpawner>().corrutineIsActive = false;

        gameOverScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void AddScore()
    {
        score++;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameScreen.SetActive(false);
        Time.timeScale = 0;

        GetRaitingOfgame();
    }

    public void GetRaitingOfgame()
    {
        ScoreCounter counter = FindObjectOfType<ScoreCounter>();

        counter.AddScoreInList(score);
        CurrentScor.text  = score.ToString();
        BiggestScore.text = counter.biggestScore().ToString();
}

}
