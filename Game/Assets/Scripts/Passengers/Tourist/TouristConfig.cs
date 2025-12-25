using UnityEngine;

[CreateAssetMenu(fileName = "TouristConfig", menuName = "Scriptable Objects/TouristConfig")]
public class TouristConfig : BasePassengerConfig
{
    [Range(1.1f, 1.7f)]
    public float damageMultiplier;
}
