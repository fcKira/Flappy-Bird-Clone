using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    [field: SerializeField] public Player Player { get; private set; }

    [field: SerializeField] public ScreenGO GameplayScreen { get; private set; }

    [field: SerializeField] public MainMenuScreen MainMenuScreen { get; private set; }

    [field: SerializeField] public ScreenPause PauseScreen { get; private set; }

    [field: SerializeField] public ScreenCountdown CountdownScreen { get; private set; }

    [field: SerializeField] public GameplayCanvas GameplayCanvas { get; private set; }

    public FSM<GameStates> _FSM { get; private set; }

    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else Instance = this;

        _FSM = new FSM<GameStates>();

        IState<GameStates> menu = new MenuState(this);
        _FSM.AddState(GameStates.Menu, menu);

        IState<GameStates> gameplay = new GameplayState(this);
        _FSM.AddState(GameStates.Gameplay, gameplay);

        IState<GameStates> pause = new PauseState(this);
        _FSM.AddState(GameStates.Pause, pause);

        IState<GameStates> countdown = new CountdownState(this);
        _FSM.AddState(GameStates.Countdown, countdown);
    }

    private void Start()
    {
        ScreenManager.Instance.Push(GameplayScreen);
        _FSM.ChangeState(GameStates.Menu);
    }

    public void PauseGameplay()
    {
        _FSM.ChangeState(GameStates.Pause);
    }

    public void StartCountdown()
    {
        _FSM.ChangeState(GameStates.Countdown);
    }

    public void GoToGameplay()
    {
        _FSM.ChangeState(GameStates.Gameplay);
    }

    public void GoToMainMenu()
    {
        _FSM.ChangeState(GameStates.Menu);
    }
}
