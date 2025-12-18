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
    [SerializeField] private StudentController studentPrefab;
    [SerializeField] private BullyController bullyPrefab;
    [SerializeField] private GrannyController grannyPrefab;
    [SerializeField] private BusinessmanController businessmanPrefab;
    [SerializeField] private TouristController touristPrefab;

    public override void InstallBindings()
    {
        //Конфиги
        Container.BindInstance(grannyConfig).AsSingle();
        Container.BindInstance(bullyConfig).AsSingle();
        Container.BindInstance(touristConfig).AsSingle();
        Container.BindInstance(businessmanConfig).AsSingle();
        Container.BindInstance(studentConfig).AsSingle();
        //Фабрики
        Container.Bind<StudentFactory>().AsSingle().WithArguments(studentPrefab);
        Container.Bind<BullyFactory>().AsSingle().WithArguments(bullyPrefab);
        Container.Bind<GrannyFactory>().AsSingle().WithArguments(grannyPrefab);
        Container.Bind<BusinessmanFactory>().AsSingle().WithArguments(businessmanPrefab);
        Container.Bind<TouristFactory>().AsSingle().WithArguments(touristPrefab);
        //Сущность автобуса
        Container.Bind<BusModel>().AsSingle();
        //Коорды для спавна
        Container.Bind<Transform>().WithId("SpawnRoot").FromInstance(passengersRoot);
        //Entry Point
        Container.BindInterfacesAndSelfTo<GameplayEntryPoint>().FromInstance(entryPoint).AsSingle();
    }
}
