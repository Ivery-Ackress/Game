using UnityEngine;
using Zenject;

/*
 * 1) Если 1 интерфейс : Bind<IMyService>().To<MyService>().AsSingle();
 * 2) Если несколько интерфейсов/может быть нужен как класс : BindInterfacesAndSelfTo<MyService>().AsSingle();
 * 3) Для конкретных объектов, что уже созданы : BindInstance(myObject);
 */
public class GameplayInstaller : MonoInstaller
{
    [Header("Ядро")]
    [SerializeField] private GameplayEntryPoint entryPoint;
    [SerializeField] private Transform passengersRoot;
    [Header("Конфиги")]
    [SerializeField] private GrannyConfig grannyConfig;
    [SerializeField] private BullyConfig bullyConfig;
    [SerializeField] private TouristConfig touristConfig;
    [SerializeField] private BusinessmanConfig businessmanConfig;
    [SerializeField] private StudentConfig studentConfig;
    [Header("Префабы")]
    [SerializeField] private GameObject studentPrefab;
    [SerializeField] private GameObject bullyPrefab;
    [SerializeField] private GameObject grannyPrefab;
    [SerializeField] private GameObject businessmanPrefab;
    [SerializeField] private GameObject touristPrefab;

    public override void InstallBindings()
    {
        //Конфиги
        Container.BindInstance(grannyConfig).AsSingle();
        Container.BindInstance(bullyConfig).AsSingle();
        Container.BindInstance(touristConfig).AsSingle();
        Container.BindInstance(businessmanConfig).AsSingle();
        Container.BindInstance(studentConfig).AsSingle();
        //Фабрика
        Container.Bind<PassengerFactory>()
            .AsSingle()
            .WithArguments(
                passengersRoot,
                grannyPrefab,
                studentPrefab,
                businessmanPrefab,
                bullyPrefab,
                touristPrefab
            );
        //Сущность автобуса
        //Container.Bind<BusModel>().AsSingle();
        //Entry Point
        Container.BindInterfacesAndSelfTo<GameplayEntryPoint>()
            .FromInstance(entryPoint)
            .AsSingle();
    }
}