using UnityEngine;
using Zenject;

public class StudentController : MonoBehaviour
{
    private StudentModel model;
    private BusModel busModel;
    private float currentCooldown;

    [Inject]
    public void Construct(BusModel busModel)
    {
        this.busModel = busModel;
    }

    public void Initialize(StudentModel model)
    {
        this.model = model;
        currentCooldown = 0f;
    }

    private void Update()
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
            return;
        }
        TryRepair();
    }

    private void TryRepair()
    {
        if (!model.CanRepair() || busModel.CurrentHealth >= busModel.MaxHealth)
            return;
        busModel.Repair(model.RepairAmount);
        currentCooldown = model.RepairCooldown;
    }
}
