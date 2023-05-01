using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : ScreenUI
{
    [SerializeField] IScreen _mainMenuScreen;

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
