using System;
using Zenject;

//Вынесены общие параметры сущностей в абстрактный класс, дабы не дублировать код на каждую модель
public abstract class BasePassengerModel
{
    public PassengerType PassengerType;
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }
    public PassengerStateEnum CurrentState { get; private set; }

    public event Action<int> HealthChanged;
    public event Action<PassengerStateEnum> StateChanged;

    protected BasePassengerModel(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        CurrentState = PassengerStateEnum.Inactive;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth < 0) 
            CurrentHealth = 0;
        HealthChanged?.Invoke(CurrentHealth);
        if (CurrentHealth == 0)
            ChangeState(PassengerStateEnum.Death);
    }

    protected void ChangeState(PassengerStateEnum newState)
    {
        if (this.CurrentState != newState)
        {
            this.CurrentState = newState;
            this.StateChanged?.Invoke(newState);
        }
    }
}

