using UnityEngine;

public class TouristModel : BasePassengerModel
{
    public float DamageMultiplier { get; }

    public TouristModel(TouristConfig config) : base(config.passengerMaxHp)
    {
        this.DamageMultiplier = config.damageMultiplier;
    }
}
