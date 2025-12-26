using UnityEngine;

[CreateAssetMenu(fileName = "TouristConfig", menuName = "Scriptable Objects/TouristConfig")]
public class TouristConfig : BasePassengerConfig
{
    [Range(1.1f, 1.7f)]
    [SerializeField] private float damageMultiplier;
    
    public float DamageMultiplier => damageMultiplier;

    public float GetUpgradeDamageMultiplier(int currentLevel)
    {
        return damageMultiplier * currentLevel;
    }
}
