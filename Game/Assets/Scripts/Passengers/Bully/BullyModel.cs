using UnityEngine;

public class BullyModel : BasePassengerModel
{
    public int AttackDamage { get; private set; }
    public float AttackCooldown { get; private set; }

    public BullyModel(BullyConfig config) : base(config.maxHp)
    {
        AttackDamage = config.attackDamage;
        AttackCooldown = config.attackCooldown;
    }

    public bool CanAttack() => this.CurrentState == PassengerStateEnum.Active;
}
