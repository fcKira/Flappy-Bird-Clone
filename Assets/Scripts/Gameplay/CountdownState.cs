using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownState : IState<GameStates>
{
    GameManager _gameManager;
    public CountdownState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void OnEnter(GameStates fromState)
    {
        ScreenManager.Instance.Push(_gameManager.CountdownScreen);

        if (fromState == GameStates.Menu)
        {
            _gameManager.Player.PlayerInGameplay();
        }

        _gameManager.GameplayCanvas.GameplayInitialize();

        Debug.Log("CountdownState In");
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        ScreenManager.Instance.Pop();
        Debug.Log("CountdownState Out");
    }
}

