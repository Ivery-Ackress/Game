using UnityEngine;

[CreateAssetMenu(fileName = "LevelTwoConfig", menuName = "Scriptable Objects/LevelTwoConfig")]
public class LevelTwoConfig : ScriptableObject
{
    //В будущем придется менять string на localizedstring, но пока для наглядности так.
    [Header("Элементы для UI")]
    public string busTwoDescription = "Транспортная кампания постаралась. Перед вами модифицированный 65 автобус.";
    public Sprite busTwoSprite;

    [Header("Основные параметры")]
    public GameObject busOnePrefab; //нужен префаб
    public int priceToUnlock = 2000;
    public int leftFlankHp = 1250;
    public int rightFlankHp = 1250;
    public int seatsQuantity = 32;
    public bool hasCannon = true;
}
