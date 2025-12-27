using System;

public class CurrencyModel
{
    private int coins;

    public int Coins
    {
        get => coins;
        set
        {
            if (coins == value) return;
            coins = value;
            OnCoinsChanged?.Invoke(coins);
        }
    }

    public event Action<int> OnCoinsChanged;

    public CurrencyModel(int initialCoins)
    {
        coins = initialCoins;
    }
}
