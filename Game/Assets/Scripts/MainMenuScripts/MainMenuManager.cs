using System;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject continuePanel;
    [SerializeField] private GameObject settingsPanel;


    public void StartNewGame()
    {
        Debug.Log("Start");
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
