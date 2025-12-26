using UnityEngine;

[CreateAssetMenu(fileName = "GrannyConfig", menuName = "Scriptable Objects/GrannyConfig")]
public class GrannyConfig : BasePassengerConfig
{
    [Tooltip("Коэффицент впитываемого урона")]
    [Range(0.25f, 0.75f)]
    [SerializeField] private float absorptionRate;

    public float AbsorptionRate => absorptionRate;

    public float GetUpgradeAbsorptionRate(int currentLevel)
    {
        return absorptionRate * currentLevel;
    }
}
