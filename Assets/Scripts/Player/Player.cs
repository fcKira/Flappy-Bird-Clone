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

    [SerializeField] RuntimeAnimatorController _gameplayAnimatorController;
    [SerializeField] RuntimeAnimatorController _menuAnimatorController;

    PlayerModel _myModel;
    PlayerController _myController;
    PlayerView _myView;

    Vector3 _startPosition;
    Quaternion _startRotation;
    Vector3 _velocityCached;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();

        _myModel = new PlayerModel(this);
        _myView = new PlayerView(this);
        _myController = new PlayerController(_myModel);

        _myModel.OnFlap += _myView.TriggerFlap;

        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    private void OnEnable()
    {
        Rigidbody.useGravity = true;
        Rigidbody.velocity = _velocityCached;
    }

    private void OnDisable()
    {
        _velocityCached = Rigidbody.velocity;

        Rigidbody.velocity = Vector3.zero;
        Rigidbody.useGravity = false;
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

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;

        Rigidbody.velocity = _velocityCached = Vector3.zero;
    }

    public void PlayerInMenu()
    {
        _myView.SetAnimatorController(_menuAnimatorController);
    }

    public void PlayerInGameplay()
    {
        _myView.SetAnimatorController(_gameplayAnimatorController);
    }
}
