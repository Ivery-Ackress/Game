using UnityEngine;

public interface ISaveLoadModule
{
    void Fill(GameSaveData data); //композиция
    void Apply(GameSaveData data); //декомпозиция
}
