using Zenject;

/*
 * По традиции пишу объяснение (как понял) в 1ом файле, в будущем отшлифуем и вынесем все в отдельную псевдо-документацию
 * Цикл zenject (Сервис (интерфейс/конкретный класс) -> installer (состоит из биндов, у которых к тому же и куча chain методов есть) 
 * -> context (определяем в какой сцене) -> inject (ура, работает))
 * Context : scene, project, gameobject, decorator (для scene, если сервисы пересекаются, но инсталлеры разные... huh?)
 * А, и еще. В инсталлерах наследуемся от MonoInstaller, либо чисто Installer (но в нашем случае MonoInstaller) + перегружаем BSI
 */
public class BootStrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Container.Bind<IInputService>().Какой-тоЧейнМетод();
        //Container.Bind<SomeClass>().Какой-тоЧейнМетод();
    }
}
