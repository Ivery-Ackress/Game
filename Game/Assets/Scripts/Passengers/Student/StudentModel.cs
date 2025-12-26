public class StudentModel : BasePassengerModel
{
    public int RepairAmount { get; }
    public float RepairCooldown { get; }

    public StudentModel(StudentConfig config) : base(config.PassengerMaxHp)
    {
        this.RepairCooldown = config.RepairCooldown;
        this.RepairAmount = config.RepairAmount;
    }

    public bool CanRepair() => CurrentState == PassengerStateEnum.Active;
}
