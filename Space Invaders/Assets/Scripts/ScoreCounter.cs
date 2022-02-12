using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] public int bestScoreCounter = 0;
    public Text scoreText;
    public PlayerController health;
    public GameObject gameOverMenu, menuButton, leftButt,rightbutt;
    public Text scoreAtGameOver;
    public Text bestScore; 
    int score = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
            bestScoreCounter = PlayerPrefs.GetInt("BestScore");
    }
    void Update()
    {
        if (health.healthCount <= -1)
            IsGameOver();

        scoreText.text = "—чет:" + score;
    }
    public void FirstAddToScore() //прибавка к счелу дл€ €первого типа врагов
    {
        score++;
    }
    public void SecondAddToScore()//прибавка к счелу дл€ второго типа врагов
    {
        score+=2;
    }
    public void IsGameOver()
    {

        gameOverMenu.SetActive(true);
        menuButton.SetActive(false);
        leftButt.SetActive(false);
        leftButt.SetActive(false);

        Time.timeScale = 0;
        scoreAtGameOver.text = "—чет: " + score;
        if (bestScoreCounter < score)
        {
            bestScoreCounter = score;
            PlayerPrefs.SetInt("BestScore", bestScoreCounter);
        }

        bestScore.text = "Ћучший счет: " + bestScoreCounter;
    }
}
