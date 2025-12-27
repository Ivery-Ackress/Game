using UnityEngine;

public interface ISaveLoadModule
{
    void Get(GameSaveData data); //композиция
    void Set(GameSaveData data); //декомпозиция
}
