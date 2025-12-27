using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PassengersSaveData
{
    public Dictionary<PassengerType, int> passengerDictionary = new();
}
