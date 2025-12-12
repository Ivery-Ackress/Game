using Zenject;
using UnityEngine;

public class BullyFactory : IPassengerFactory
{
    private readonly DiContainer container;
    private readonly BullyController prefab;

    public BullyFactory(DiContainer container, BullyController prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public MonoBehaviour Create(Transform parent)
    {
        var model = container.Instantiate<BullyModel>();
        var controller = container.InstantiatePrefabForComponent<BullyController>(prefab, parent);
        controller.Initialize(model);
        return controller;
    }
}
