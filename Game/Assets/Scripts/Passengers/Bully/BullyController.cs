using UnityEngine;
using Zenject;

public class BullyController : MonoBehaviour
{
    private BullyModel model;
    private float fireTimer;

    public void Initialize(BullyModel model)
    {
        this.model = model;
        fireTimer = 0f;
    }

    private void Update()
    {
        if (fireTimer > 0f)
            fireTimer -= Time.deltaTime;

        if (model.CurrentState == PassengerStateEnum.Active)
            TryAttack();
    }

    private void TryAttack()
    {
        if (fireTimer > 0f)
            return;
        //***************************
        //Логика стрельбы (рейкасты)*
        //***************************
        fireTimer = model.AttackCooldown;
    }
}
