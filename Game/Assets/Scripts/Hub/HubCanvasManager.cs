using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;
using Zenject;

public class HubCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject traderPanel;
    [SerializeField] private TMP_Text coinsCount;

    [Header("Bus Info")]
    [SerializeField] private Transform busSpawnPoint;
    [SerializeField] private Button previousBusButton;
    [SerializeField] private Button buyBusButton;
    [SerializeField] private TMP_Text busCost;
    [SerializeField] private TMP_Text busDescription;
    [SerializeField] private Button nextBusButton;
    [SerializeField] private List<BusBuyingManager> buses;

    [SerializeField] private int currentBusIndex = 0;
    private GameObject currentBus;

    private CurrencyModel currencyModel;
    private CurrencyController currencyController;

    [Inject]
    public void Construct(CurrencyModel currencyModel, CurrencyController currencyController)
    {
        this.currencyModel = currencyModel;
        this.currencyController = currencyController;
    }

    private void Start()
    {
        currencyModel.OnCoinsChanged += UpdateCoinsUI;
        UpdateCoinsUI(currencyModel.Coins);
        UpdateBusSection();
    }

    private void OnDestroy()
    {
        currencyModel.OnCoinsChanged -= UpdateCoinsUI;
    }

    private void UpdateCoinsUI(int coins)
    {
        coinsCount.text = coins.ToString();
    }

    private void UpdateBusSection()
    {
        if (currentBus != null)
            Destroy(currentBus);

        previousBusButton.gameObject.SetActive(currentBusIndex != 0);

        nextBusButton.gameObject.SetActive(currentBusIndex != buses.Count - 1);

        buyBusButton.gameObject.SetActive(!buses[currentBusIndex].IsAlreadyBuying);
        busCost.text = $"Buy: {buses[currentBusIndex].Bus.PriceToUnlock}";
        
        busDescription.text = buses[currentBusIndex].Bus.Description;

        currentBus = Instantiate(
            buses[currentBusIndex].Bus.Prefab,
            busSpawnPoint.position,
            busSpawnPoint.rotation
        );
    }
    
    public void PreviousBus()
    {
        currentBusIndex--;
        UpdateBusSection();
    }

    public void NextBus()
    {
        currentBusIndex++;
        UpdateBusSection();
    }

    public void BuyBus()
    {
        if (currencyController.TrySpend(buses[currentBusIndex].Bus.PriceToUnlock))
        {
            buses[currentBusIndex].IsAlreadyBuying = true;
            UpdateBusSection();
        }
    }

    public void OpenTraderPanel()
    {
        traderPanel.SetActive(true);
    }
}
