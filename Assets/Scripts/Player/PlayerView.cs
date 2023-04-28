using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView
{
    Player _myPlayer;

    public PlayerView(Player myPlayer)
    {
        _myPlayer = myPlayer;
    }

    public void TriggerFlap()
    {
        _myPlayer.Animator.SetTrigger("Flap");
    }
}
