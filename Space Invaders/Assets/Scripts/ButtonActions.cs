using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonActions : MonoBehaviour
{
    public GameObject MainMenu, SettingsMenu;
    public AudioSource audioSource;
    public GameObject ttoogle;
    public bool SoundOn = true;
    bool IsSettingsActive = false;
    int starttime;
    private void Start()
    {
        MainMenu.SetActive(false);
    }
    private void Update()
    {//задержка в пооявлении меню
        starttime++;
        if (starttime == 300) {
            MainMenu.SetActive(true);
        }
    }

    //Функция перехода в игру
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("GameProces"); //переход в другую сцену
    }
    public void SettingsMenuDisplay()
    {
        if (IsSettingsActive == true) // проверка активности окна настроек
        {
            MainMenu.SetActive(true);
            SettingsMenu.SetActive(false);
            IsSettingsActive = false;
        }
        else
            if (IsSettingsActive == false)
        {
            MainMenu.SetActive(false);
            SettingsMenu.SetActive(true);
            IsSettingsActive = true;
        }
    }
    public void SoundControll()
    {
        audioSource.mute = !audioSource.mute;
        SoundOn = !SoundOn;
        Debug.Log(SoundOn);
        //вкл. выкл. звука в зависимости от параметра
    }
    public void Exit()
    {
        Application.Quit();
    }
}
