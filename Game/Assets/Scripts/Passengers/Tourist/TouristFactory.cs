using Zenject;
using UnityEngine;

public class TouristFactory : IPassengerFactory
{
    private readonly DiContainer container;
    private readonly TouristController prefab;

    public TouristFactory(DiContainer container, TouristController prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public MonoBehaviour Create(Transform parent)
    {
        var model = container.Instantiate<TouristModel>();
        var controller = container.InstantiatePrefabForComponent<TouristController>(prefab, parent);
        controller.Initialize(model);
        return controller;
    }
}
