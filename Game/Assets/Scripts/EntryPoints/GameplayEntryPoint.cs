using UnityEngine;
using Zenject;

//Теста ради
public class GameplayEntryPoint : MonoBehaviour, IInitializable
{
    private GrannyModel _granny;

    // Zenject сам создаст бабку и передаст её сюда
    [Inject]
    public void Construct(GrannyModel granny)
    {
        _granny = granny;
    }

    public void Initialize()
    {
        Debug.Log($"1. Бабка создана. HP: {_granny.CurrentHealth}/{_granny.MaxHealth}. State: {_granny.CurrentState}");
        var absorbedInactive = _granny.AbsorbDamage(50);
        Debug.Log($"2. Попытка танкануть 50 урона в Inactive. Поглощено: {absorbedInactive} (Ожидалось: -1)");
        Debug.Log("3. Бьем бабку напрямую (TakeDamage 30)...");
        _granny.TakeDamage(30);
        Debug.Log($"   HP после удара: {_granny.CurrentHealth} (Ожидалось: {_granny.MaxHealth - 30})");
        Debug.Log("4. Добиваем бабку (Урон 1000)...");
        _granny.TakeDamage(1000);
        Debug.Log($"   HP: {_granny.CurrentHealth}. State: {_granny.CurrentState} (Ожидалось: Death)");
    }
}
