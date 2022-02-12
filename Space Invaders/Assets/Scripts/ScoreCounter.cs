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
            scoreAtGameOver.text = "����: " + score;
            if (BestScoreCounter < score)
            {
                BestScoreCounter = score;
                PlayerPrefs.SetInt("BestScore", BestScoreCounter);
            }

            BestScore.text = "������ ����: " + BestScoreCounter;
        }

        ScoreText.text = "����:" + score;
    }
    public void FirstAddToScore() //�������� � ����� ��� �������� ���� ������
    {
        score++;
    }
    public void SecondAddToScore()//�������� � ����� ��� ������� ���� ������
    {
        score+=2;
    }
}
