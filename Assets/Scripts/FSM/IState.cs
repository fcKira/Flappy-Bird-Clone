using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T>
{
    void OnEnter(T fromState);

    void OnUpdate();

    void OnExit();
}
