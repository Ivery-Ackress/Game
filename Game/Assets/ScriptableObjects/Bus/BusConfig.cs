using UnityEngine;

[CreateAssetMenu(fileName = "LevelTwoConfig", menuName = "Scriptable Objects/LevelTwoConfig")]
public class LevelTwoConfig : ScriptableObject
{
    //В будущем придется менять string на localizedstring, но пока для наглядности так.
    [Header("Элементы для UI")]
    public string description;
    public Sprite icon;

    [Header("Основные параметры")]
    public GameObject prefab;
    public int priceToUnlock; 
    public int leftFlankHp;
    public int rightFlankHp;
    public int seatsQuantity;
    public bool hasCannon;
}
