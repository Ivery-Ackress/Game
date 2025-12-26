using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TraderPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject traderPanel;
    [SerializeField] private GameObject shopElementPrefab;
    [SerializeField] private Transform container;
    [SerializeField] private List<PassengerUpgadeManager> passengers;
    [SerializeField] private TMP_Text coinsCount;

    public int Coins
    {
        get
        {
            if (int.TryParse(coinsCount.text, out int result))
                return result;
            return 0;
        }
        private set
        {
            coinsCount.text = value.ToString();
        }
    }

    public void CloseAndSave()
    {
        //Save();
        traderPanel.SetActive(false);
    }

    public void Start()
    {
        CreateShopElements();
        
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
    private void Upgrade(ShopElement element, PassengerUpgadeManager passenger)
    {
        if (passenger.PassengerConfig.GetUpgradeCost(passenger.Level) <= Coins)
        {
            Coins -= passenger.PassengerConfig.GetUpgradeCost(passenger.Level);
            passenger.Level++;
            UpdateShopElement(element, passenger);
        }
    }

    private void UpdateShopElement(ShopElement element, PassengerUpgadeManager passenger)
    {
        element.cost.text = $"{passenger.PassengerConfig.GetUpgradeCost(passenger.Level)}";
        element.image.sprite = passenger.PassengerConfig.PassengerSprite;
        element.name.text = passenger.PassengerConfig.PassengerName;
        element.description.text = passenger.PassengerConfig.PassengerDescription;
    }
}
