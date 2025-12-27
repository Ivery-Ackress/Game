using Unity.VisualScripting;
using UnityEngine;

public class CurrencySaveLoadModule : ISaveLoadModule
{
    private readonly CurrencyModel currencyModel;

    public CurrencySaveLoadModule(CurrencyModel currencyModel)
    {
        this.currencyModel = currencyModel;
    }

    public void Get(GameSaveData data)
    {
        if (data.currencySaveData == null)
            data.currencySaveData = new CurrencySaveData();
        data.currencySaveData.currency = currencyModel.Coins;
    }

    public void Set(GameSaveData data)
    {
        if (data.currencySaveData == null) return;
        currencyModel.Coins = data.currencySaveData.currency;
    }
}
