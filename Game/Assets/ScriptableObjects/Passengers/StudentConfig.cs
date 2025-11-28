using UnityEngine;

[CreateAssetMenu(fileName = "StudentConfig", menuName = "Scriptable Objects/StudentConfig")]
public class StudentConfig : ScriptableObject
{
    //В будущем придется менять string на localizedstring, но пока для наглядности так.
    [Header("Элементы для UI")]
    public string studentName = "Студент-ремонтник";
    public string studentFunction = "Медленно восстанавливает прочность корпуса";
    public string studentPlacement = "В проходе, с инструментами";
    public string studentDeath = "Пьет энергетик и ловит инфаркт";
    public Sprite studentSprite;

    [Header("Основные параметры")]
    public GameObject studentPrefab; //найти префаб
    public int maxHp = 40;
    public int cost = 130;
}
