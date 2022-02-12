using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ButtonActions : MonoBehaviour
{
    [SerializeField] public static bool soundOn = true;
    public GameObject mainMenu, settingsMenu;
    public AudioSource audioSource;
    bool isSettingsActive = false;
    int starttime;
    int bestScore;
    public Text bestScoreText;
    private void Start()
    {
        mainMenu.SetActive(false);
        ShowBestScore();
        CheckSound();
        
    }

    void ShowBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
            bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = bestScore.ToString();
    }
    private void CheckSound()
    {
        if (soundOn == true)
        {
            audioSource.mute = false;
        }
        else
            if (soundOn == false)
        {
            audioSource.mute = true;
        }
    }

    private void Update()
    {//�������� � ���������� ����
        starttime++;
        if (starttime == 300) {
            mainMenu.SetActive(true);
        }

        CheckSound();
    }

    //������� �������� � ����
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("GameProces"); //������� � ������ �����
    }
    public void SettingsMenuDisplay()
    {
        if (isSettingsActive == true) // �������� ���������� ���� ��������
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
            isSettingsActive = false;
        }
        else
            if (isSettingsActive == false)
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
            isSettingsActive = true;
        }
    }
    public void SoundControll()
    {
        soundOn = !soundOn;
       
        Debug.Log(soundOn);
        //���. ����. ����� � ����������� �� ���������
    }
    public void Exit()
    {
        Application.Quit();
    }
}
