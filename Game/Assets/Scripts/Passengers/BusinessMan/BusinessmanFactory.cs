using Zenject;
using UnityEngine;

public class BusinessmanFactory : IPassengerFactory
{
    private readonly DiContainer container;
    private readonly BusinessmanController prefab;

    public BusinessmanFactory(DiContainer container, BusinessmanController prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public MonoBehaviour Create(Transform parent)
    {
        var model = container.Instantiate<BusinessmanModel>();
        var controller = container.InstantiatePrefabForComponent<BusinessmanController>(prefab, parent);
        controller.Initialize(model);
        return controller;
    }
}
