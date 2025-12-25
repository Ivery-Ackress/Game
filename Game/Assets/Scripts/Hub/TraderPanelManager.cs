using TMPro;
using UnityEngine;

public class TraderPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject traderPanel;
    [SerializeField] private GameObject shopElementPrefab;
    [SerializeField] private Transform container;
    public void CloseAndSave()
    {
        //Save();
        traderPanel.SetActive(false);
    }

    public void Start()
    {
        for (var i = 0; i < 9; i++)
        {
            var shopElement = Instantiate(shopElementPrefab, container);

            var uiShopElement = shopElement.GetComponent<ShopElement>();
            uiShopElement.cost.text = "100";
            uiShopElement.sprite = null;
            uiShopElement.name.text = "name";
            uiShopElement.description.text = "description";

            uiShopElement.button.onClick.AddListener(() =>
            {
                Upgrade(uiShopElement);
            });
        }
    }

    public void Upgrade(ShopElement element)
    {
        element.name.text = "It Works!";
    }
}
