using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;

    public Text scoreText;
    public Text GameOverText;
    public Text restartText;
    public int score;

    private bool gameOver;
    private bool restart;

    private void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
             Application.Quit();
             Debug.Log("sa");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }

            
        }
    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            
            for (int i = 0; i < spawnCount; i++)
            {


                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                //Coroutine
                // *IEnumerator döndürmek zorundadır
                // *En az bir adet yield ifadesi bulunmalı
                // çağrlırken StartCourautine ile çağırılmalı
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(4);
            if (gameOver == true)
            {
                restartText.text = "Press 'R' For Restart\nPress 'Q' For Quit";
                restart = true;
                break;
            }
        }
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over";
        gameOver = true;
    }
    void Start()
    {
        GameOverText.text = "";
        restartText.text = "";
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnValues());

    }
}
