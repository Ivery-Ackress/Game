using Zenject;

/*
 * По традиции пишу объяснение (как понял) в 1ом файле, в будущем отшлифуем и вынесем все в отдельную псевдо-документацию
 * Цикл zenject (Сервис (интерфейс/конкретный класс) -> installer (состоит из биндов, у которых к тому же и куча chain методов есть) 
 * -> context (определяем в какой области видимости) -> inject (ура, работает))
 * Context : scene, project, gameobject, decorator (для scene, если сервисы пересекаются, но инсталлеры разные... huh?)
 * А, и еще. В инсталлерах наследуемся от MonoInstaller, либо чисто Installer (но в нашем случае MonoInstaller)
 * В нативном шарпе полезен IDisposable, который позволяет писать метод Dispose.
 * Благодаря методу Dispose мы можем в нужный нам момент отписываться от объектов без ожидания отработки GC.
 * 
 */
public class BootStrapInstaller : MonoInstaller
{
    //Принцип написания показан ниже (перегружаем IB). Чейн методов много, см.документацию
    public override void InstallBindings()
    {
        /*
         * 1) Если 1 интерфейс : Bind<IMyService>().To<MyService>().AsSingle();
         * 2) Если несколько интерфейсов/может быть нужен как класс : BindInterfacesAndSelfTo<MyService>().AsSingle();
         * 3) Для конкретных объектов, что уже созданы : BindInstance(myObject);
         */
    }
}
