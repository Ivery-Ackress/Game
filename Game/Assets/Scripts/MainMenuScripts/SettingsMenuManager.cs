using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private AudioMixer audioMixer;

    [Header("Display Elements")]
    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle isFullScreenToggle;
    [SerializeField] private TMPro.TMP_Dropdown qualityDropdown;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundsSlider;

    private Resolution[] resolutions;
    private GameSettings settings = new();
    private string savePath;
    private string defaultSettingsPath;


    private void Start()
    {
        savePath = Path.Combine(Application.dataPath, "Json files", "settings.json");
        defaultSettingsPath = Path.Combine(Application.dataPath, "Json files", "defaultSettings.json");

        CreateResolutions();

        LoadSettings();

        ApplyLoadedSettingsInUI();
        ApplyLoadedSettingsInSystem();
    }

    public void SaveSettings()
    {
        if (settings == null)
        {
            Debug.LogWarning("No settings to save");
            return;
        }

        var json = JsonUtility.ToJson(settings, true);

        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save settings: {e.Message}");
        }
    }

    private void LoadSettings()
    {
        if (File.Exists(savePath))
        {
            try
            {
                var json = File.ReadAllText(savePath);
                settings = JsonUtility.FromJson<GameSettings>(json);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Failed to load settings: {e.Message}");
                settings = new GameSettings();
            }
        }
        else
        {
            Debug.Log("No settings file found, creating new one");
            settings = new GameSettings();
        }
    }

    private void ApplyLoadedSettingsInUI()
    {
        if (settings == null) return;

        musicSlider.value = settings.musicVolume;
        soundsSlider.value = settings.soundsVolume;
        qualityDropdown.value = settings.qualityIndex;
        isFullScreenToggle.isOn = settings.isFullScreen;
        resolutionDropdown.value = settings.resolutionIndex;
    }

    private void ApplyLoadedSettingsInSystem()
    {
        if (settings == null) return;

        audioMixer.SetFloat("MusicVolume", Mathf.Log10(settings.musicVolume) * 20);
        audioMixer.SetFloat("SoundsVolume", Mathf.Log10(settings.soundsVolume) * 20);
        QualitySettings.SetQualityLevel(settings.qualityIndex);
        Screen.fullScreen = settings.isFullScreen;

        var resolution = resolutions[settings.resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, settings.isFullScreen);
    }

    private void CreateResolutions()
    {
        resolutionDropdown.ClearOptions();

        resolutions = Screen.resolutions;
        var currentResolutionIndex = 0;

        resolutionDropdown.AddOptions(
            resolutions
            .Select((resolution, resolutionIndex) =>
            {
                if (Screen.currentResolution.width == resolution.width && Screen.currentResolution.height == resolution.height)
                    currentResolutionIndex = resolutionIndex;
                return $"{resolution.width} x {resolution.height}";
            })
            .ToList()
            );
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void CloseAndSave()
    {
        SaveSettings();
        settingsPanel.SetActive(false);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        settings.qualityIndex = qualityIndex;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        settings.isFullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        var resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        settings.resolutionIndex = resolutionIndex;
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);

        settings.musicVolume = volume;
    }

    public void SetSoundsVolume(float volume)
    {
        audioMixer.SetFloat("SoundsVolume", Mathf.Log10(volume) * 20);

        settings.soundsVolume = volume;
    }

    public void ReturnToDefault()
    {
        try
        {
            var json = File.ReadAllText(defaultSettingsPath);
            var defaultSettings = JsonUtility.FromJson<GameSettings>(json);

            settings = defaultSettings;

            ApplyLoadedSettingsInUI();
            ApplyLoadedSettingsInSystem();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to restore default settings: {e.Message}");
        }
    }
}