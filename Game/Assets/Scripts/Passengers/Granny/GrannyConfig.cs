using UnityEngine;

[CreateAssetMenu(fileName = "GrannyConfig", menuName = "Scriptable Objects/GrannyConfig")]
public class GrannyConfig : BasePassengerConfig
{
    [Tooltip("Коэффицент впитываемого урона")]
    [Range(0.25f, 0.75f)]
    public float absorptionRate;
}
