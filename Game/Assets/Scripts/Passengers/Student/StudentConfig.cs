using UnityEngine;

[CreateAssetMenu(fileName = "StudentConfig", menuName = "Scriptable Objects/StudentConfig")]
public class StudentConfig : BasePassengerConfig
{
    [Range(10f, 20f)]
    public float repairCooldown;
    [Range(30, 50)]
    public int repairAmount;
    [Range(3, 6)]
    public int repairStep;
    [Range(0.5f,1.5f)]
    public float stepDuration;
}
