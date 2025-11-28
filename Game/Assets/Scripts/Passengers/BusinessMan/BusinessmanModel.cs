using UnityEngine;

public class BusinessmanModel : BasePassengerModel
{
    private readonly BusinessmanConfig _config;

    public BusinessmanModel(BusinessmanConfig config) : base(config.maxHp)
    {
        _config = config;
    }
}
