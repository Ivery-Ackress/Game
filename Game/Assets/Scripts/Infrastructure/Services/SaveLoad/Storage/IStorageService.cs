using System;
using UnityEngine;

public interface IStorageService
{
    //Реализация с лавки без callback'a (операции то синхронные)
    void Save<T>(string key, T data);
    T Load<T>(string key);
}
