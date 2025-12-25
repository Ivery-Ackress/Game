using UnityEngine;
using Zenject;


public class GrannyController : MonoBehaviour
{
    private GrannyModel model;

    public void Initialize(GrannyModel model)
    {
        this.model = model;
    }

    public int AbsorbDamage(int incomingDamage)
    {
        if (model.CurrentState != PassengerStateEnum.Active) 
            return 0;
        var absorbed = Mathf.Min(incomingDamage, model.CurrentHealth);
        model.TakeDamage(absorbed);
        return absorbed;
    }
}
