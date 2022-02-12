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

        scoreText.text = "����:" + score;
    }
    public void FirstAddToScore() //�������� � ����� ��� �������� ���� ������
    {
        score++;
    }
    public void SecondAddToScore()//�������� � ����� ��� ������� ���� ������
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
        scoreAtGameOver.text = "����: " + score;
        if (bestScoreCounter < score)
        {
            bestScoreCounter = score;
            PlayerPrefs.SetInt("BestScore", bestScoreCounter);
        }

        bestScore.text = "������ ����: " + bestScoreCounter;
    }
}
