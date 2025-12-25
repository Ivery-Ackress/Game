using UnityEngine;

[CreateAssetMenu(fileName = "NewBus", menuName = "Scriptable Objects/NewBus")]
public class BusConfig : ScriptableObject
{
    //В будущем придется менять string на localizedstring, но пока для наглядности так.
    [Header("Элементы для UI")]
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;

    [Header("Основные параметры")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private int priceToUnlock;
    [SerializeField] private int leftFlankHp;
    [SerializeField] private int rightFlankHp;
    [SerializeField] private int seatsQuantity;
    [SerializeField] private bool hasCannon;

    [Header("Для магазина")]
    [SerializeField] private bool isAlreadyBuying;

    
    public string Description => description;
    public Sprite Icon => icon;
    public GameObject Prefab => prefab;
    public int PriceToUnlock => priceToUnlock;
    public int LeftFlankHp => leftFlankHp;
    public int RightFlankHp => rightFlankHp;
    public int SeatsQuantity => seatsQuantity;
    public bool HasCannon => hasCannon;
    
    public bool IsAlreadyBuying
    {
        get => isAlreadyBuying;
        set => isAlreadyBuying = value;
    }
}
