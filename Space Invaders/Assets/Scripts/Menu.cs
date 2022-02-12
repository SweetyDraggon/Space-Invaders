using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject menuPanel, menuButton,rightBut,leftBut;
    public AudioSource audioSource;
    public static bool soundOn;

    private void Start()
    {
        soundOn = ButtonActions.soundOn;
        Debug.Log(soundOn);
        SoundCheck();

    }

    private void SoundCheck()
    {
        if (soundOn == false)
        {
            audioSource.mute = true;
        }
        else
            audioSource.mute = false;
    }

    public void OpenMenu() //открытие основного меню
    {
        menuButton.SetActive(false);
        menuPanel.SetActive(true);
        rightBut.SetActive(false);
        leftBut.SetActive(false);
        Time.timeScale = 0f;

    }
    public void Continue() //закрытие меню и прдолжение игры
    {
        menuButton.SetActive(true);
        menuPanel.SetActive(false);
        rightBut.SetActive(true);
        leftBut.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
