using UnityEngine;

public class BasePassengerConfig : ScriptableObject
{
    [Header("Идентификация")]
    [SerializeField] PassengerType passengerType;

    [Header("Элементы для UI")]
    [SerializeField] private string passengerName;
    [SerializeField] private string passengerFunction;
    [SerializeField] private string passengerPlacement;
    [SerializeField] private string passengerDeath;
    [SerializeField] private Sprite passengerSprite;

    [Header("Основные параметры")]
    [SerializeField] private int passengerMaxHp;

    [Header("Параметры для магазина")]
    [SerializeField] private int passengerCost;
    [SerializeField] private float costMarkup;
    [SerializeField] private string passengerDescription;

    public PassengerType PassengerType => passengerType;
    public string PassengerName => passengerName;
    public string PassengerFunction => passengerFunction;
    public string PassengerPlacement => passengerPlacement;
    public string PassengerDeath => passengerDeath;
    public Sprite PassengerSprite => passengerSprite;
    public int PassengerMaxHp => passengerMaxHp;
    public int PassengerCost => passengerCost;
    public float CostMarkup => costMarkup;
    public string PassengerDescription => passengerDescription;

    public virtual int GetUpgradeCost(int currentLevel)
    {
        return Mathf.RoundToInt(passengerCost * costMarkup * currentLevel);
    }
}
