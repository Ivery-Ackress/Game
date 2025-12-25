// Scripts/Infrastructure/Factories/PassengerFactory.cs
using UnityEngine;
using Zenject;

public class PassengerFactory
{
    private readonly DiContainer container;
    private readonly Transform spawnParent;
    private readonly GameObject grannyPrefab;
    private readonly GameObject studentPrefab;
    private readonly GameObject businessmanPrefab;
    private readonly GameObject bullyPrefab;
    private readonly GameObject touristPrefab;

    //Zenject вызовет конструктор и передаст самостоятельно передаст аргументы из Installer
    public PassengerFactory(
        DiContainer container,
        Transform spawnParent,
        GameObject grannyPrefab,
        GameObject studentPrefab,
        GameObject businessmanPrefab,
        GameObject bullyPrefab,
        GameObject touristPrefab)
    {
        this.container = container;
        this.spawnParent = spawnParent;
        this.grannyPrefab = grannyPrefab;
        this.studentPrefab = studentPrefab;
        this.businessmanPrefab = businessmanPrefab;
        this.bullyPrefab = bullyPrefab;
        this.touristPrefab = touristPrefab;
    }

    public BasePassengerModel Create(BasePassengerConfig config)
    {
        //Создаем модель через Zenject контейнер
        BasePassengerModel model = config switch
        {
            GrannyConfig grannyConfig => container.Instantiate<GrannyModel>(new object[] { grannyConfig }),
            StudentConfig studentConfig => container.Instantiate<StudentModel>(new object[] { studentConfig }),
            BusinessmanConfig businessmanConfig => container.Instantiate<BusinessmanModel>(new object[] { businessmanConfig }),
            BullyConfig bullyConfig => container.Instantiate<BullyModel>(new object[] { bullyConfig }),
            TouristConfig touristConfig => container.Instantiate<TouristModel>(new object[] { touristConfig }),
            _ => throw new System.ArgumentException($"Неизвестный тип конфига: {config.GetType()}")
        };

        //Выбираем префаб по типу конфига
        GameObject prefab = config switch
        {
            GrannyConfig => grannyPrefab,
            StudentConfig => studentPrefab,
            BusinessmanConfig => businessmanPrefab,
            BullyConfig => bullyPrefab,
            TouristConfig => touristPrefab,
            _ => throw new System.ArgumentException($"Неизвестный тип конфига: {config.GetType()}")
        };

        // Создаем GameObject из префаба
        GameObject viewObject = container.InstantiatePrefab(prefab, spawnParent);
        // var view = viewObject.GetComponent<BasePassengerView>();
        // view?.Initialize(model);
        return model;
    }
}