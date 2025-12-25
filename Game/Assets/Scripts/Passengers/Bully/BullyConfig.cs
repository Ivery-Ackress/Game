using UnityEngine;

[CreateAssetMenu(fileName = "BullyConfig", menuName = "Scriptable Objects/BullyConfig")]
public class BullyConfig : BasePassengerConfig
{
    public int attackDamage;
    public float attackCooldown;
}
