using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    [Header("Acceleration")]
    [SerializeField] private AnimationCurve _accelerationCurve;

    [Header("Input")]
    [SerializeField] private InputManager _input;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    private float _accelerationTimer;
    private Vector3 _inputDirection;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var _inputDirection = new Vector3(_input.HorizontalAxis, 0, _input.VerticalAxis).normalized;

        _accelerationTimer = _inputDirection.Equals(Vector3.zero) ? 0 : _accelerationTimer + Time.deltaTime;
       
        _moveDirection += _inputDirection * GetAcceleration() * _speed * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        Move();
        Rotate();

        _moveDirection = Vector3.zero;
    }

    private void Rotate()
    {
        if (_moveDirection.Equals(Vector3.zero))
            return;

        Quaternion toRotation = Quaternion.LookRotation(_moveDirection, transform.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 700 * Time.deltaTime);
    }

    private void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveDirection);
        
    }

    private float GetAcceleration() => 
        _accelerationCurve.Evaluate(_accelerationTimer);









}
