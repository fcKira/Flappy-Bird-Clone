using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool<T>
{
    Func<T> _FactoryMethod;

    List<T> _currentStock;

    Action<T> _TurnOnCallback;
    Action<T> _TurnOffCallback;

    public ObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialAmount)
    {
        _FactoryMethod = factoryMethod;

        _TurnOnCallback = turnOnCallback;

        _TurnOffCallback = turnOffCallback;

        _currentStock = new List<T>(initialAmount);
        
        for (int i = 0; i < initialAmount; i++)
        {
            T obj = _FactoryMethod();

            _TurnOffCallback(obj);

            _currentStock.Add(obj);
        }
    }

    public T GetObject()
    {
        T obj = default;

        if (_currentStock.Count > 0)
        {
            obj = _currentStock[0];

            _currentStock.RemoveAt(0);
        }
        else
        {
            obj = _FactoryMethod();
        }

        _TurnOnCallback(obj);

        return obj;
    }

    public void ReturnObject(T obj)
    {
        _TurnOffCallback(obj);

        _currentStock.Add(obj);
    }
}
