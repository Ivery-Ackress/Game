using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class TraderPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject traderPanel;
    [SerializeField] private GameObject shopElementPrefab;
    [SerializeField] private Transform container;
    [SerializeField] private List<PassengerUpgradeManager> passengers;
    [SerializeField] private TMP_Text coinsCount;

    private CurrencyModel currencyModel;
    private CurrencyController currencyController;

    [Inject]
    public void Construct(CurrencyModel currencyModel, CurrencyController currencyController)
    {
        this.currencyModel = currencyModel;
        this.currencyController = currencyController;
    }

    public void CloseAndSave()
    {
        //Save();
        traderPanel.SetActive(false);
    }

    public void Start()
    {
        currencyModel.OnCoinsChanged += UpdateCoinsUI;
        UpdateCoinsUI(currencyModel.Coins);
        CreateShopElements();
    }

    private void OnDestroy()
    {
        currencyModel.OnCoinsChanged -= UpdateCoinsUI;
    }

    private void UpdateCoinsUI(int coins)
    {
        coinsCount.text = coins.ToString();
    }

    private void CreateShopElements()
    {
        for (var i = 0; i < passengers.Count; i++)
        {
            var passengerInfo = passengers[i];

            var shopElement = Instantiate(shopElementPrefab, container);
            var uiShopElement = shopElement.GetComponent<ShopElement>();

            UpdateShopElement(uiShopElement, passengerInfo);

            var index = i;

            uiShopElement.button.onClick.AddListener(() =>
            {
                Upgrade(uiShopElement, passengers[index]);
            });
        }
    }
    private void Upgrade(ShopElement element, PassengerUpgradeManager passenger)
    {
        if (currencyController.TrySpend(passenger.PassengerConfig.GetUpgradeCost(passenger.Level)))
        {
            passenger.Level++;
            UpdateShopElement(element, passenger);
        }
    }

    private void UpdateShopElement(ShopElement element, PassengerUpgradeManager passenger)
    {
        element.cost.text = $"{passenger.PassengerConfig.GetUpgradeCost(passenger.Level)}";
        element.image.sprite = passenger.PassengerConfig.PassengerSprite;
        element.name.text = passenger.PassengerConfig.PassengerName;
        element.description.text = passenger.PassengerConfig.PassengerDescription;
    }
}
