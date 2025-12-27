using UnityEngine;

public class CurrencyController
{
    private readonly CurrencyModel currencyModel;

    public CurrencyController(CurrencyModel currencyModel)
    {
        this.currencyModel = currencyModel;
    }

    public bool TrySpend(int amount)
    {
        if (currencyModel.Coins < amount)
        {
            Debug.LogWarning($"Недостаточно монет: {currencyModel.Coins} < {amount}");
            return false;
        }
        currencyModel.Coins -= amount;
        return true;
    }

    public void Add(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning($"Отрицательные деньги -_-: {amount}");
            return;
        }
        currencyModel.Coins += amount;
    }

    public int GetCoins => currencyModel.Coins;
    public void SetCoins(int amount) => currencyModel.Coins = Mathf.Max(0, amount);
}
