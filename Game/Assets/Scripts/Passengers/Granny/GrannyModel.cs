using System;
using UnityEngine;
public class GrannyModel : BasePassengerModel
{
    /*
     * Создаем дублер конфига, чтоб хранить ссылку на данные для каждого объекта
     * Делается это в угоду того, чтобы конструктор (а как следствие объекты) не бухли.
     * Проще передать ссылку и забрать данные по необходимости
     * Конструктор конкретных моделей наследуется от родительского base.
     * В base передается хп с нашего конфига, который прокидывает в дочерний конструктор за нас zenject.
     */
    private readonly GrannyConfig _config; 

    public GrannyModel(GrannyConfig config) : base(config.maxHp)
    {
        _config = config;
    }

    public int AbsorbDamage(int incomingDamage)
    {
        if (CurrentState != PassengerStateEnum.Active)
            return -1;
        //Бабулька впитывает урон до тех пор, пока не умрёт
        var absorbed = Math.Min(incomingDamage, CurrentHealth);
        TakeDamage(absorbed);
        return absorbed;
    }
}
