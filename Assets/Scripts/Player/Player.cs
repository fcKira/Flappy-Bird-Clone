using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    [field: SerializeField] public float FlapForce { get; private set; }
    [field: SerializeField] public float MaxFallSpeed { get; private set; }

    PlayerModel _myModel;
    PlayerController _myController;
    PlayerView _myView;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();

        _myModel = new PlayerModel(this);
        _myView = new PlayerView(this);
        _myController = new PlayerController(_myModel);

        _myModel.OnFlap += _myView.TriggerFlap;
    }

    void Update()
    {
        _myController.ListenInputs();
    }

    private void FixedUpdate()
    {
        _myModel.HandleRotation();
        _myModel.VelocityClamp();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Could use TryGetComponent(out PipeObstacle obstacle).
        //But checking the layers in this case is better because I don't really need to get the obstacle reference
        if (other.gameObject.layer == 3)
        {
            
            Debug.Log("Touched");
        }
    }
}
