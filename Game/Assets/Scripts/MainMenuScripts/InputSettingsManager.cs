using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;
using System;

public class InputSettingsManager : MonoBehaviour
{
    #region SerializeFields
    [Header("Input Settings")]
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private GameObject bindingPrefab;
    [SerializeField] private Transform bindingsContainer;

    [Header("Rebinding Panel")]
    [SerializeField] private GameObject rebindPanel;
    [SerializeField] private TMP_Text rebindText;
    [SerializeField] private TMP_Text currentKeysText;

    [Header("Binding Combo Settings")]
    [SerializeField] private int maxComboLength = 3;
    [SerializeField] private float timeout = 3f;

    [Header("JSON Settings")]
    [SerializeField] private string settingsFileName = "input_settings.json";
    [SerializeField] private string defaultSettingsFileName = "default_input_settings.json";
    #endregion

    #region Data Fields
    private string settingsFilePath;
    private string defaultSettingsFilePath;
    #endregion

    public void Awake()
    {
        settingsFilePath = Path.Combine(Application.dataPath, "Json files", settingsFileName);
        defaultSettingsFilePath = Path.Combine(Application.dataPath, "Json files", defaultSettingsFileName);
    }

    public void Start()
    {
        LoadSettingsFromJSON();
        CreateSettingsUI();
    }

    private void CreateSettingsUI()
    {
        foreach (Transform child in bindingsContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var actionMap in inputActions.actionMaps)
        {
            foreach (var action in actionMap.actions)
            {
                CreateBindingUIElement(action);
            }
        }
    }

    private void CreateBindingUIElement(InputAction action)
    {
        var uiElement = Instantiate(bindingPrefab, bindingsContainer);

        var manager = uiElement.GetComponent<BindingPrefabManager>();

        var displayName = InputControlPath.ToHumanReadableString(
            action.bindings[0].path,
            InputControlPath.HumanReadableStringOptions.OmitDevice |
            InputControlPath.HumanReadableStringOptions.UseShortNames
        );

        manager.ActionName.text = action.name;
        manager.BindingText.text = string.IsNullOrEmpty(displayName) ? "Не назначено" : displayName;
        manager.Button.onClick.AddListener(() =>
        {
            Rebinding(action, manager.BindingText);
        });
    }

    public void Rebinding(InputAction action, TMP_Text displayText)
    {
        rebindPanel.SetActive(true);
        currentKeysText.text = "Ожидание ввода...";

        action.Disable();

        var rebindOperation = action.PerformInteractiveRebinding(0)
            .WithControlsExcluding("<Mouse>/position")
            .WithControlsExcluding("<Mouse>/delta")
            .WithControlsExcluding("<Touchscreen>/*")
            .WithTimeout(timeout)
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                var displayName = InputControlPath.ToHumanReadableString(
                       action.bindings[0].path,
                       InputControlPath.HumanReadableStringOptions.OmitDevice |
                       InputControlPath.HumanReadableStringOptions.UseShortNames);

                currentKeysText.text = string.IsNullOrEmpty(displayName) ? "Не назначено" : displayName;

                operation.Dispose();
                action.Enable();

            })
            .Start();

        rebindPanel.SetActive(false);
    }

    public void SaveSettingsToJSON()
    {
        try
        {
            var json = JsonUtility.ToJson(inputActions, true);
            File.WriteAllText(settingsFilePath, json);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save input settings: {e.Message}");
        }
    }

    private void LoadSettingsFromJSON()
    {
        try
        {
            if (File.Exists(settingsFilePath))
            {
                var json = File.ReadAllText(settingsFilePath);
                inputActions = InputActionAsset.FromJson(json);
            }
            else
            {
                var json = File.ReadAllText(defaultSettingsFilePath);
                inputActions = InputActionAsset.FromJson(json);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load input settings: {e.Message}");
        }
    }
    
    public void ResetToDefaults()
    {
        var json = File.ReadAllText(defaultSettingsFilePath);
        inputActions = InputActionAsset.FromJson(json);
        CreateSettingsUI();
    }
}