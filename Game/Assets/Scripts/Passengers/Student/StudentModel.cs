public class StudentModel : BasePassengerModel
{
    public int RepairAmount { get; }
    public float RepairCooldown { get; }

    public StudentModel(StudentConfig config) : base(config.maxHp)
    {
        this.RepairCooldown = config.repairCooldown;
        this.RepairAmount = config.repairAmount;
    }

    public bool CanRepair() => CurrentState == PassengerStateEnum.Active;
}
