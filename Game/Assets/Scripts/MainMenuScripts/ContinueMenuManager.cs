using UnityEngine;

public class ContinueMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject continuePanel;

    public void ClosePanel()
    {
        continuePanel.SetActive(false);
    }
}
