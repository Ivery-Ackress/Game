using UnityEngine;
using Zenject;

public class TouristController : MonoBehaviour
{
    private TouristModel model;

    public void Initialize(TouristModel model)
    {
        this.model = model;
    }

    private void Update()
    {
        if (model.CurrentState != PassengerStateEnum.Active) 
            return;
        //Логика наводки лазером на выбранного юнита (рейкастик)
    }
}
