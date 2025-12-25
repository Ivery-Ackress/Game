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
            GrannyConfig grannyConfig => this.container.Instantiate<GrannyModel>(new object[] { grannyConfig }),
            StudentConfig studentConfig => this.container.Instantiate<StudentModel>(new object[] { studentConfig }),
            BusinessmanConfig businessmanConfig => this.container.Instantiate<BusinessmanModel>(new object[] { businessmanConfig }),
            BullyConfig bullyConfig => this.container.Instantiate<BullyModel>(new object[] { bullyConfig }),
            TouristConfig touristConfig => this.container.Instantiate<TouristModel>(new object[] { touristConfig }),
            _ => throw new System.ArgumentException($"Неизвестный тип конфига: {config.GetType()}")
        };

        //Выбираем префаб по типу конфига
        GameObject prefab = config switch
        {
            GrannyConfig => this.grannyPrefab,
            StudentConfig => this.studentPrefab,
            BusinessmanConfig => this.businessmanPrefab,
            BullyConfig => this.bullyPrefab,
            TouristConfig => this.touristPrefab,
            _ => throw new System.ArgumentException($"Неизвестный тип конфига: {config.GetType()}")
        };

        // Создаем GameObject из префаба
        GameObject viewObject = this.container.InstantiatePrefab(prefab, this.spawnParent);
        // var view = viewObject.GetComponent<BasePassengerView>();
        // view?.Initialize(model);
        return model;
    }
}