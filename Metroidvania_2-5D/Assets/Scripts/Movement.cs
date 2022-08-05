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


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var inputDirection = new Vector3(_input.HorizontalAxis, 0, _input.VerticalAxis).normalized;

        _accelerationTimer = inputDirection.Equals(Vector3.zero) ? 0 : _accelerationTimer + Time.deltaTime;
       
        _moveDirection += inputDirection * GetAcceleration() * _speed * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveDirection);
        _moveDirection = Vector3.zero;
    }

    private float GetAcceleration() => 
        _accelerationCurve.Evaluate(_accelerationTimer);









}
