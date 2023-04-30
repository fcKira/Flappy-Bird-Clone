using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : IState<GameStates>
{
    GameManager _gameManager;

    public EndGameState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void OnEnter(GameStates fromState)
    {
        ScreenManager.Instance.Push(_gameManager.EndGameScreen);
        _gameManager.GameplayCanvas.HideAllScores();
        Debug.Log("EndGameState In");
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        ScreenManager.Instance.Pop();
        Debug.Log("EndGameState Out");
    }
}
