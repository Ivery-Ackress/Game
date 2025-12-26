using UnityEngine;

public class BusinessmanModel : BasePassengerModel
{
    public float MoneyPerSecond { get; }
    public BusinessmanModel(BusinessmanConfig config) : base(config.PassengerMaxHp)
    {
        MoneyPerSecond = config.MoneyPerSecond;
    }
}
