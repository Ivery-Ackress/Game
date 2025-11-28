using UnityEngine;

public class BullyModel : BasePassengerModel
{
    private readonly BullyConfig _config;

    BullyModel(BullyConfig config) : base(config.maxHp)
    {
        _config = config;
    }


}
