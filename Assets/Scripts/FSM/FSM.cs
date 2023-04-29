using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    IState<T> _currentState;

    Dictionary<T, IState<T>> _allStates = new Dictionary<T, IState<T>>();

    T _fromState;

    public void AddState(T key, IState<T> value)
    {
        if (!_allStates.ContainsKey(key)) _allStates.Add(key, value);
        else _allStates[key] = value;
    }

    public void ChangeState(T nextState)
    {
        if (_currentState != null) _currentState.OnExit();
        
        _currentState = _allStates[nextState];
        _currentState.OnEnter(_fromState);
        _fromState = nextState;
    }

    public void Update()
    {
        _currentState.OnUpdate();
    }
}
