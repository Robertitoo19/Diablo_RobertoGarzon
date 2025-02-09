using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenesmanagement : MonoBehaviour
{
    [SerializeField] private GameObject principal;
    [SerializeField] private GameObject settings;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Settings()
    {
        principal.SetActive(false);
        settings.SetActive(true);
    }
    public void Principal()
    {
        principal.SetActive(true);
        settings.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
