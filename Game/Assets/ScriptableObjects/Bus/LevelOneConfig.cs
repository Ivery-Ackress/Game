using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelOneConfig", menuName = "Scriptable Objects/LevelOneConfig")]
public class LevelOneConfig : ScriptableObject
{
    //В будущем придется менять string на localizedstring, но пока для наглядности так.
    [Header("Элементы для UI")]
    public string busOneDescription = "Ваш начальный 56 автобус. Хоть и ржавый, но на первое время пойдет";
    public Sprite busOneSprite;

    [Header("Основные параметры")]
    public GameObject busOnePrefab; //нужен префаб
    public int leftFlankHp = 750;
    public int rightFlankHp = 750;
    public int seatsQuantity = 20;
    public bool hasCannon = false;
}
