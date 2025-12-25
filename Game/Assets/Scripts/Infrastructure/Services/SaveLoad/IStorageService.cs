using System;
using UnityEngine;

public interface IStorageService<T>
{
    /*
     * В лавке предлагалось делать callback, успешен ли сейв или нет, но в данном случае я вижу в этом 0 смысла
     * Логика простая : Save будет сохранять какую-то дату по ключу, Load будет эту дату возвращать обратно, обращаясь к ключу.
     */
    void Save(string key, T data);
    T Load(string key);
}
