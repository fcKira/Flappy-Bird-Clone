using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IState<GameStates>
{
    GameManager _gameManager;

    public PauseState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void OnEnter(GameStates fromState)
    {
        ScreenManager.Instance.Push(_gameManager.PauseScreen);
        Debug.Log("PauseState In");
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        ScreenManager.Instance.Pop();
        Debug.Log("PauseState Out");
    }
}
