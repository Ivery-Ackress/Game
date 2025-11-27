using System;
using Zenject;

//Два вопросительных знака, под нож
public abstract class BasePassengerModel
{
    public int CurrentHealth { get;  set; }
    public int MaxHealth { get; set; }
    public PassengerState CurrentState { get; set; }

    public event Action<int> OnHealthChanged;
    public event Action<PassengerState> OnStateChanged;

    [Inject]
    public void Construct(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth < 0) 
            CurrentHealth = 0;
        OnHealthChanged?.Invoke(CurrentHealth);
        if (CurrentHealth == 0)
            ChangeState(PassengerState.Leaving);
    }

    protected void ChangeState(PassengerState newState)
    {
        CurrentState = newState;
        OnStateChanged?.Invoke(newState);
    }
}

