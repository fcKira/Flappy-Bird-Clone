using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
