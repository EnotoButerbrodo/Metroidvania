using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] [Range(0,30)]private float _speedPlayer = 10;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] [Range(0,10)] private float _playerHeight = 3;
 
    [SerializeField] private float _gravity;
    private Vector3 _velocity;
    private bool _isGrounded;
    private float ZeroPointerVelocity = 0f; // нужно для того, что бы задать игроку минимум, за который он не сможет упасть
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        
    }


    
    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundcheck.position,_groundDistance,_groundMask);

       
        if(Input.GetAxis("Jump") == 1 &&  _isGrounded) 
        {
            JumpPlayer();
        }
    }

    private void JumpPlayer()
    {
        _velocity.y = Mathf.Sqrt(_playerHeight * -2f * _gravity);
       // Debug.Log("Jump");
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * _speedPlayer * Time.deltaTime);

         // без этого условия позиция игрока будет уходить в минус всегда
        // поэтому если нужно упасть с высоты, он сразу окажется на большей позиции чем должен был быть.
        // к примеру, он находится на позиции y = 0, а velocity уменьшается всегда,
        // то при падении игрок резко перескочит на позиции velocity
 

        if(_isGrounded && _velocity.y < 0)
        {
            _velocity.y = ZeroPointerVelocity;
           
        } 

        // гравитация delta y = 1/2 * g * t^2;
        _velocity.y += _gravity * Time.deltaTime;  
        _controller.Move(_velocity * Time.deltaTime);  
    }
} 
