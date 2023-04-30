using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : IState<GameStates>
{
    GameManager _gameManager;

    public MenuState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void OnEnter(GameStates fromState)
    {
        ScreenManager.Instance.Push(_gameManager.MainMenuScreen);

        if (fromState == GameStates.Endgame)
        {
            _gameManager.Player.ResetPlayer();
            _gameManager.GameplayCanvas.StartInitialize();
            _gameManager.ObstacleHandler.Dispose();
        }

        _gameManager.Player.PlayerInMenu();
        Debug.Log("MenuState In");
    }

    public void OnUpdate()
    {
        
    }

    public void OnExit()
    {
        ScreenManager.Instance.Pop();
        Debug.Log("MenuState Out");
    }
}
