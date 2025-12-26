using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject continuePanel;
    [SerializeField] private GameObject settingsPanel;


    public void StartNewGame()
    {
        SceneManager.LoadScene("Hub");
    }
    public void OpenContinuePanel()
    {
        continuePanel.SetActive(true);
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
}
