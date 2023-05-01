using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController
{
    PlayerModel _model;

    public PlayerController(PlayerModel model)
    {
        _model = model;
    }

    public void ListenInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _model.Flap();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bool isOnButton;

#if UNITY_ANDROID && !UNITY_EDITOR
            isOnButton = EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#else
            isOnButton = EventSystem.current.IsPointerOverGameObject();
#endif
            if (!isOnButton)
            {
                _model.Flap();
            }
        }
    }
}
