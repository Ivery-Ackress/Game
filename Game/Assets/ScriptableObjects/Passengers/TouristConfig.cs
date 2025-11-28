using UnityEngine;

[CreateAssetMenu(fileName = "TouristConfig", menuName = "Scriptable Objects/TouristConfig")]
public class TouristConfig : ScriptableObject
{
    //В будущем придется менять string на localizedstring, но пока для наглядности так.
    [Header("Элементы для UI")]
    public string touristName = "Турист-Наводчик";
    public string touristFunction = "Помечает врага, увеличивая урон по нему";
    public string touristPlacement = "На верхнем этаже";
    public string touristDeath = "Падает с автобуса";
    public Sprite touristSprite;

    [Header("Основные параметры")]
    public GameObject touristPrefab; //найти префаб
    public int maxHp = 100;
    public int cost = 150;
}
