using Zenject;

public class HubInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        /*
          * 1) Если 1 интерфейс : Bind<IMyService>().To<MyService>().AsSingle();
          * 2) Если несколько интерфейсов/может быть нужен как класс : BindInterfacesAndSelfTo<MyService>().AsSingle();
          * 3) Для конкретных объектов, что уже созданы : BindInstance(myObject);
          */
    }
}