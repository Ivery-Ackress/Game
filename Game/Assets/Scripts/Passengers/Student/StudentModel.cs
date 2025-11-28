using UnityEngine;

public class StudentModel : BasePassengerModel
{
    private readonly StudentConfig _config;

    public StudentModel(StudentConfig config) : base(config.maxHp)
    {
        _config = config;
    }
}
