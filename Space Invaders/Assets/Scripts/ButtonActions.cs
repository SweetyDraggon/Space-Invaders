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
    {//задержка в пооявлении меню
        starttime++;
        if (starttime == 300) {
            mainMenu.SetActive(true);
        }

        CheckSound();
    }

    //Функция перехода в игру
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("GameProces"); //переход в другую сцену
    }
    public void SettingsMenuDisplay()
    {
        if (isSettingsActive == true) // проверка активности окна настроек
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
        //вкл. выкл. звука в зависимости от параметра
    }
    public void Exit()
    {
        Application.Quit();
    }
}
