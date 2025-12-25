using Zenject;

/*
 * По традиции пишу объяснение (как понял) в 1ом файле, в будущем отшлифуем и вынесем все в отдельную псевдо-документацию
 * Цикл zenject (Сервис (интерфейс/конкретный класс) -> installer (состоит из биндов, у которых к тому же и куча chain методов есть) 
 * -> context (определяем в какой области видимости) -> inject (ура, работает))
 * Context : scene, project, gameobject, decorator (для scene, если сервисы пересекаются, но инсталлеры разные... huh?)
 * А, и еще. В инсталлерах наследуемся от MonoInstaller, либо чисто Installer (но в нашем случае MonoInstaller)
 * В нативном шарпе полезен IDisposable, который позволяет писать метод Dispose.
 * Благодаря методу Dispose мы можем в нужный нам момент отписываться от объектов без ожидания отработки GC.
 */

//Тут будут лежать глобальные для проекта сервисы (сейв/лоуд, баланс и прокачка игрока..)
public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Сервисы (порядок важен — SaveLoadService первый)
       // Container.Bind<SaveLoadService>().AsSingle();
       // Container.Bind<GameSessionService>().AsSingle();
        //Container.Bind<CurrencyService>().AsSingle();

        // Инициализатор (загрузит сохранения при старте) - точка входа в сам проект по сути
       // Container.BindInterfacesTo<GameInitializer>().AsSingle();
    }
}
