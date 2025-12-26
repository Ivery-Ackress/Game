using UnityEngine;

public class PassengerUpgadeManager : MonoBehaviour
{
    [SerializeField] private BasePassengerConfig passengerConfig;
    [SerializeField] private int level;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public BasePassengerConfig PassengerConfig => passengerConfig;
}
