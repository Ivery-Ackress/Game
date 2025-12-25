using UnityEngine;

public class TraderPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject traderPanel;


    public void CloseAndSave()
    {
        //Save();
        traderPanel.SetActive(false);
    }
}
