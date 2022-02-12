using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] public int BestScoreCounter = 0;
    public Text ScoreText;
    public PlayerController Health;
    public GameObject GameOverMenu, MenuButton;
    public Text scoreAtGameOver;
    public Text BestScore; 
    int score = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
            BestScoreCounter = PlayerPrefs.GetInt("BestScore");
    }
    void Update()
    {
        if (Health.HealthCount <= -1) 
        {
            GameOverMenu.SetActive(true);
            MenuButton.SetActive(false);
            Time.timeScale = 0;
            scoreAtGameOver.text = "—чет: " + score;
            if (BestScoreCounter < score)
            {
                BestScoreCounter = score;
                PlayerPrefs.SetInt("BestScore", BestScoreCounter);
            }

            BestScore.text = "Ћучший счет: " + BestScoreCounter;
        }

        ScoreText.text = "—чет:" + score;
    }
    public void FirstAddToScore() //прибавка к счелу дл€ €первого типа врагов
    {
        score++;
    }
    public void SecondAddToScore()//прибавка к счелу дл€ второго типа врагов
    {
        score+=2;
    }
}
