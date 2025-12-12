using Zenject;
using UnityEngine;

//Переписать через дженерики можно, слишком много бойлерплейт кода у фабрики каждого из пассажиров
public class GrannyFactory : IPassengerFactory
{
    private readonly DiContainer container;
    private readonly GrannyController prefab;

    public GrannyFactory(DiContainer container, GrannyController prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public MonoBehaviour Create(Transform parent)
    {
        var model = container.Instantiate<GrannyModel>();
        var controller = container.InstantiatePrefabForComponent<GrannyController>(prefab, parent);
        controller.Initialize(model);
        return controller;
    }
}
