using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject MenuPanel, MenuButton,rightBut,leftBut;
    public AudioSource audioSource;

    public void OpenMenu() //открытие основного меню
    {
        MenuButton.SetActive(false);
        MenuPanel.SetActive(true);
        rightBut.SetActive(false);
        leftBut.SetActive(false);
        Time.timeScale = 0f;

    }
    public void Continue() //закрытие меню и прдолжение игры
    {
        MenuButton.SetActive(true);
        MenuPanel.SetActive(false);
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
