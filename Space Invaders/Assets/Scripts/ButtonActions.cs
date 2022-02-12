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
    {//�������� � ���������� ����
        starttime++;
        if (starttime == 300) {
            MainMenu.SetActive(true);
        }
    }

    //������� �������� � ����
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("GameProces"); //������� � ������ �����
    }
    public void SettingsMenuDisplay()
    {
        if (IsSettingsActive == true) // �������� ���������� ���� ��������
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
        //���. ����. ����� � ����������� �� ���������
    }
    public void Exit()
    {
        Application.Quit();
    }
}
