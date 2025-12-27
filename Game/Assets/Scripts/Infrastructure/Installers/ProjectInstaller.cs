using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Модели
        Container.Bind<CurrencyModel>().AsSingle().WithArguments(10000);
        //Контроллеры
        Container.Bind<CurrencyController>().AsSingle();
        //Сервисы
        Container.Bind<IStorageService>().To<StorageService>().AsSingle();
        //Модули SaveLoad
        Container.Bind<ISaveLoadModule>().To<CurrencySaveLoadModule>().AsSingle();
        //Оркестратор
        Container.Bind<SaveLoadManager>().AsSingle();
    }
}
