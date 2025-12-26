using UnityEngine;

[CreateAssetMenu(fileName = "StudentConfig", menuName = "Scriptable Objects/StudentConfig")]
public class StudentConfig : BasePassengerConfig
{
    [Range(10f, 20f)]
    [SerializeField] private float repairCooldown;

    [Range(30, 50)]
    [SerializeField] private int repairAmount;
    
    [Range(3, 6)]
    [SerializeField] private int repairStep;
    
    [Range(0.5f,1.5f)]
    [SerializeField] private float stepDuration;

    public float RepairCooldown => repairCooldown;
    public int RepairAmount => repairAmount;
    public int RepairStep => repairStep;
    public float StepDuration => stepDuration;
    
    public float GetUpgradeSomething(int currentLevel)
    {
        return repairCooldown * currentLevel;
    }
}
