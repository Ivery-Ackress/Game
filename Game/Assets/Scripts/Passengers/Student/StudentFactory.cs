using Zenject;
using UnityEngine;

public class StudentFactory : IPassengerFactory
{
    private readonly DiContainer container;
    private readonly StudentController prefab;

    public StudentFactory(DiContainer container, StudentController prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public MonoBehaviour Create(Transform parent)
    {
        var model = container.Instantiate<StudentModel>();
        var controller = container.InstantiatePrefabForComponent<StudentController>(prefab, parent);
        controller.Initialize(model);
        return controller;
    }
}
