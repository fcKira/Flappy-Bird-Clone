using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : IState<GameStates>
{
    GameManager _gameManager;

    public GameplayState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void OnEnter(GameStates fromState)
    {
        _gameManager.GameplayCanvas.UnpauseGame();

        Debug.Log("GameplayState In");
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        Debug.Log("GameplayState Out");
    }
}
