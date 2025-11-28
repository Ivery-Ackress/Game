using UnityEngine;

[CreateAssetMenu(fileName = "GrannyConfig", menuName = "Scriptable Objects/GrannyConfig")]
public class GrannyConfig : ScriptableObject
{
    //В будущем придется менять string на localizedstring, но пока для наглядности так.
    [Header("Элементы для UI")]
    public string grannyName = "Бабка-броня";
    public string grannyFunction = "Поглощает урон по борту, рядом с которым сидит";
    public string grannyPlacement = "У окна на своем сиденье";
    public string grannyDeath = "Выходит из автобуса с руганью";
    public Sprite grannySprite;

    [Header("Основные параметры")]
    public GameObject grannyPrefab; //найти префаб
    public int maxHp = 200;
    public int cost = 200;
}
