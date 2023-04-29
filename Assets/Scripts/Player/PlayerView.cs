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

    public void SetAnimatorController(RuntimeAnimatorController newController)
    {
        _myPlayer.Animator.enabled = true;
        _myPlayer.Animator.runtimeAnimatorController = newController;
    }

    public void TriggerFlap()
    {
        _myPlayer.Animator.SetTrigger("Flap");
    }
}
