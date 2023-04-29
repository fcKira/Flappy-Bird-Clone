using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUI : MonoBehaviour, IScreen
{
    Button[] _buttons;

    void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();

    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);

        foreach (var button in _buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Deactivate()
    {
        foreach (var button in _buttons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void Free()
    {
        gameObject.SetActive(false);
    }
}
