using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    Stack<IScreen> _screenStack;

    static public ScreenManager Instance { get; private set; }

    void Awake()
    {
        if (Instance) Destroy(gameObject);
        else Instance = this;

        _screenStack = new Stack<IScreen>();
    }

    public void Pop()
    {
        if (_screenStack.Count <= 1) return;

        _screenStack.Pop().Free();

        if (_screenStack.Count > 0)
        {
            _screenStack.Peek().Activate();
        }
    }

    public void Push(IScreen newScreen)
    {
        if (_screenStack.Count > 0)
        {
            _screenStack.Peek().Deactivate();
        }

        _screenStack.Push(newScreen);

        newScreen.Activate();
    }

    public void Switch(IScreen newScreen)
    {
        if (_screenStack.Count > 0)
        {
            _screenStack.Pop().Free();
        }

        _screenStack.Push(newScreen);

        newScreen.Activate();
    }
}
