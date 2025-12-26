using UnityEngine;

public class BullyModel : BasePassengerModel
{
    public int AttackDamage { get; private set; }
    public float AttackCooldown { get; private set; }

    public BullyModel(BullyConfig config) : base(config.PassengerMaxHp)
    {
        AttackDamage = config.AttackDamage;
        AttackCooldown = config.AttackCooldown;
    }

    public bool CanAttack() => this.CurrentState == PassengerStateEnum.Active;
}
