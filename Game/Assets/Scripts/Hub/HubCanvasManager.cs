using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private List<BusConfig> buses;

    private int currentBusIndex = 0;
    private GameObject currentBus;

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

    private void Start()
    {
        UpdateBusSection();
    }

    private void UpdateBusSection()
    {
        if (currentBus != null)
            Destroy(currentBus);

        previousBusButton.gameObject.SetActive(currentBusIndex != 0);

        nextBusButton.gameObject.SetActive(currentBusIndex != buses.Count - 1);

        buyBusButton.gameObject.SetActive(!buses[currentBusIndex].IsAlreadyBuying);
        busCost.text = $"Buy: {buses[currentBusIndex].PriceToUnlock}";
        
        busDescription.text = buses[currentBusIndex].Description;

        currentBus = Instantiate(
            buses[currentBusIndex].Prefab,
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
        if (buses[currentBusIndex].PriceToUnlock <= Coins)
        {
            buses[currentBusIndex].IsAlreadyBuying = true;
            Coins -= buses[currentBusIndex].PriceToUnlock;
            UpdateBusSection();
        }
    }

    public void OpenTraderPanel()
    {
        traderPanel.SetActive(true);
    }
}
