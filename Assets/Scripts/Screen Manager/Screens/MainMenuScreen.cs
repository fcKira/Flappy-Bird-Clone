using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : ScreenUI
{
    [SerializeField] GameObject _buttonExit;

    public override void Activate()
    {
        base.Activate();

        CheckPlatform();
    }

    void CheckPlatform()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        _buttonExit.SetActive(true);
#else
        _buttonExit.SetActive(false);
#endif
    }

    public void BTN_Play()
    {
        GameManager.Instance.StartCountdown();
    }

    public void BTN_Quit()
    {
        //Here I could Push a new Screen or enable a window to ask to the user if he really wants to quit
        Application.Quit();
    }

    public void BTN_DeleteHighscore()
    {
        GameManager.Instance.ResetHighscore();
    }
}
