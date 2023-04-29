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
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                _model.Flap();
            }
        }
    }

}
