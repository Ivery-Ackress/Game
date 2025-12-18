using UnityEngine;
using Zenject;

public class BusinessmanController : MonoBehaviour
{
    private BusinessmanModel model;
    private float moneyTimer;

    public void Initialize(BusinessmanModel model)
    {
        this.model = model;
        moneyTimer = 0f;
    }

    private void Update()
    {
        if (model.CurrentState != PassengerStateEnum.Active) 
            return;
        moneyTimer += Time.deltaTime;
        if (moneyTimer >= 1f)
        {
            moneyTimer -= 1f;
            // GenerateMoney() с привязкой к счету игрока 
        }
    }
}
