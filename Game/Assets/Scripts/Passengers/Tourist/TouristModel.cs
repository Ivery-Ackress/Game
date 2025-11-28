using UnityEngine;

public class TouristModel : BasePassengerModel
{
    private readonly TouristConfig _config;
    public TouristModel(TouristConfig config) : base(config.maxHp)
    {
        _config = config;
    }


}
