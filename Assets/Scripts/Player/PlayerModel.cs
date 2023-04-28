using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerModel
{
    Player _myPlayer;

    Vector3 _currentRotation;
    Vector3 _currentVelocity;

    public event Action OnFlap = delegate { };

    public PlayerModel(Player player)
    {
        _myPlayer = player;

        _currentRotation = _myPlayer.transform.eulerAngles;
    }

    public void Flap()
    {
        RestartVelocity();
        _myPlayer.Rigidbody.AddForce(Vector3.up * _myPlayer.FlapForce, ForceMode.VelocityChange);
        OnFlap();
    }

    public void VelocityClamp()
    {
        if (_myPlayer.Rigidbody.velocity.y < -_myPlayer.MaxFallSpeed)
        {
            _currentVelocity = _myPlayer.Rigidbody.velocity;
            _currentVelocity.y = -_myPlayer.MaxFallSpeed;
            _myPlayer.Rigidbody.velocity = _currentVelocity;
        }
    }

    public void HandleRotation()
    {
        _currentRotation.z = -_myPlayer.Rigidbody.velocity.y;

        _currentRotation.z = (_currentRotation.z < 0) ? Mathf.Max(_currentRotation.z * 3f, -90f) : Mathf.Min(_currentRotation.z * 5, 90f);

        _myPlayer.transform.rotation = Quaternion.Euler(_currentRotation);
    }

    void RestartVelocity()
    {
        _myPlayer.Rigidbody.velocity = Vector3.zero;
    }
}
