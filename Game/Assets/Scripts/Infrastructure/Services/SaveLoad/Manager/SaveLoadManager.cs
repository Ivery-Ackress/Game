using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager
{
    private readonly IStorageService storageService;
    private readonly List<ISaveLoadModule> modules;
    private const string SAVE_KEY = "game_save";

    public SaveLoadManager(IStorageService storageService, List<ISaveLoadModule> modules)
    {
        this.modules = modules;
        this.storageService = storageService;

        Debug.Log($"[SaveLoadManager] Constructor: modules count = {modules.Count}");
    }

    public void Save()
    {
        Debug.Log("[SaveLoadManager] Save() START");

        var dataToSave = new GameSaveData();

        foreach (var module in modules)
        {
            Debug.Log($"[SaveLoadManager] Calling Get() on {module.GetType().Name}");
            module.Get(dataToSave);
        }

        storageService.Save(SAVE_KEY, dataToSave);
        Debug.Log("[SaveLoadManager] Save() END");
    }

    public void Load()
    {
        Debug.Log("[SaveLoadManager] Load() START");

        var loadedData = storageService.Load<GameSaveData>(SAVE_KEY);

        if (loadedData == null)
        {
            Debug.LogWarning("[SaveLoadManager] No save file found, creating new");
            loadedData = new GameSaveData();
        }
        else
        {
            Debug.Log("[SaveLoadManager] Save file loaded successfully");
        }

        foreach (var module in modules)
        {
            Debug.Log($"[SaveLoadManager] Calling Set() on {module.GetType().Name}");
            module.Set(loadedData);
        }

        Debug.Log("[SaveLoadManager] Load() END");
    }
}
