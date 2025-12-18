public class BusModel
{
    //Затычка, реализую сущность нормально позже
    public int CurrentHealth { get; set; } = 1000;
    public int MaxHealth { get; set; } = 1000;

    public void Repair(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
    }
}
