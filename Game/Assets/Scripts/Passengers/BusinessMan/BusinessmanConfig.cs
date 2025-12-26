using UnityEngine;

[CreateAssetMenu(fileName = "BusinessmanConfig", menuName = "Scriptable Objects/BusinessmanConfig")]
public class BusinessmanConfig :  BasePassengerConfig
{
    [SerializeField] private float moneyPerSecond;

    public float MoneyPerSecond => moneyPerSecond;

    public float GetUpgradeMoneyPerSecond(int currentLevel)
    {
        return moneyPerSecond * currentLevel;
    }
}
