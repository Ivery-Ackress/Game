using UnityEngine;

[CreateAssetMenu(fileName = "BusConfig", menuName = "Scriptable Objects/BusConfig")]
public class BusConfig : ScriptableObject
{
    [Header("Идентификация")]
    [Range(1,3)]
    public int busLevel;
    public string busName;

    [Header("Характеристики")]
    [Range(750, 5000)]
    public int leftFlankMaxHP;
    [Range(750, 5000)]
    public int rightFlankMaxHP;
    [Range(5,40)]
    public int passengerSlots;

    [Header("Прокачка")]
    [Range(1000, 8000)]
    public int priceToUnlock;

    [Header("Префаб")]
    [Tooltip("Если собираемся делать разные модельки автобусов (видимо нет)")]
    public GameObject busPrefab;
}
