using UnityEngine;

[CreateAssetMenu(fileName = "BullyConfig", menuName = "Scriptable Objects/BullyConfig")]
public class BullyConfig : BasePassengerConfig
{
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackCooldown;

    public int AttackDamage => attackDamage;
    public float AttackCooldown => attackCooldown;

    public float GetUpgradeAttackCooldown(int currentLevel)
    {
        return attackCooldown * currentLevel;
    }
}
