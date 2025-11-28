using UnityEngine;

[CreateAssetMenu(fileName = "BusinessmanConfig", menuName = "Scriptable Objects/BusinessmanConfig")]
public class BusinessmanConfig : ScriptableObject
{
    //В будущем придется менять string на localizedstring, но пока для наглядности так.
    [Header("Элементы для UI")]
    public string businessmanName = "Бизнесмен-генератор";
    public string businessmanFunction = "Пассивно генерирует внутриигровые кредиты";
    public string businessmanPlacement = "Сидит и работает за ноутбуком на любом свободном сидении";
    public string businessmanDeath = "Теряет сознание после взрыва ноутбука";
    public Sprite businessmanSprite;

    [Header("Основные параметры")]
    public GameObject businessmanPrefab; //todo : префаб
    public int maxHp = 50;
    public int cost = 125;
}
