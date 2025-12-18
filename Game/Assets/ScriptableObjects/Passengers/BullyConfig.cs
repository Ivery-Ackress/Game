using UnityEngine;

[CreateAssetMenu(fileName = "BullyConfig", menuName = "Scriptable Objects/BullyConfig")]
public class BullyConfig : ScriptableObject
{
    //В будущем придется менять string на localizedstring, но пока для наглядности так.
    [Header("Элементы для UI")]
    public string bullyName = "Хулиган-стрелок";
    public string bullyFunction = "Ведет огонь по врагам из окна";
    public string bullyPlacement = "Высовывается из окна";
    public string bullyDeath = "Вываливается из окна, будучи оглушенным";
    public Sprite bullySprite;

    [Header("Основные параметры")]
    public GameObject bullyPrefab; //опять же префаб
    public int maxHp = 120;
    public int cost = 140;
    public int attackDamage = 12;
    public float attackCooldown = 0.5f;
}
