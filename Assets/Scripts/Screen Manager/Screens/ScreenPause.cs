using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPause : ScreenUI
{
    public void BTN_ReturnMainMenu()
    {
        GameManager.Instance.GoToEnd();
    }

    public void BTN_BackToGame()
    {
        GameManager.Instance.StartCountdown();
    }
}
