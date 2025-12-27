using UnityEngine;

public class BusBuyingManager : MonoBehaviour
{
    [SerializeField] private BusConfig bus;
    [SerializeField] private bool isAlreadyBuying = false;
    public BusConfig Bus => bus;

    public bool IsAlreadyBuying
    {
        get { return isAlreadyBuying; }
        set { isAlreadyBuying = value; }
    }
}
