using UnityEngine;

public class BasePassengerConfig : ScriptableObject
{
    [Header("Элементы для UI")]
    public string passengerName;
    public string passengerFunction;
    public string passengerPlacement;
    public string passengerDeath;
    public Sprite passengerSprite;

    [Header("Основные параметры")]
    public int passengerMaxHp;
    public int passengerCost;
}
