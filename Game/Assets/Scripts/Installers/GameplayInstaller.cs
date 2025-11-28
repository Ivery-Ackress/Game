using UnityEngine;
using Zenject;

/*
 * 1) Если 1 интерфейс : Bind<IMyService>().To<MyService>().AsSingle();
 * 2) Если несколько интерфейсов/может быть нужен как класс : BindInterfacesAndSelfTo<MyService>().AsSingle();
 * 3) Для конкретных объектов, что уже созданы : BindInstance(myObject);
 */
public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameplayEntryPoint entryPoint;
    [SerializeField] private GrannyConfig grannyConfig;
    [SerializeField] private BullyConfig bullyConfig;
    [SerializeField] private TouristConfig touristConfig;
    [SerializeField] private BusinessmanConfig businessmanConfig;
    [SerializeField] private StudentConfig studentConfig;
    public override void InstallBindings()
    {
        //Создаем SO в единственном экземпляре для их прокидки
        Container.BindInstance(grannyConfig).AsSingle();
        Container.BindInstance(bullyConfig).AsSingle();
        Container.BindInstance(touristConfig).AsSingle();
        Container.BindInstance(businessmanConfig).AsSingle();
        Container.BindInstance(studentConfig).AsSingle();

        //Ленивое создание объектов классов Model блока.
        Container.Bind<GrannyModel>().AsTransient();
        Container.Bind<BullyModel>().AsTransient();
        Container.Bind<TouristModel>().AsTransient();
        Container.Bind<BusinessmanModel>().AsTransient();
        Container.Bind<StudentModel>().AsTransient();

        Container.BindInterfacesAndSelfTo<GameplayEntryPoint>().FromInstance(entryPoint).AsSingle();
    }
}
