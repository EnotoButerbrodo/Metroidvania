using UnityEngine;

sealed class Player_fristCamera : Player
{  
    private void Update()
    {
        IsGrounded = Physics.CheckSphere(Groundcheck.position,GroundDistance,GroundMask);       
        if(Input.GetAxis("Jump") == 1 &&  IsGrounded) 
        {
            JumpPlayer();
        }
    }


    private void FixedUpdate()
    {  
        GravityPlayer();
         MovePlayer();
    }

     private  void GravityPlayer()
    {
        // без этого условия позиция игрока будет уходить в минус всегда
        // поэтому если нужно упасть с высоты, он сразу окажется на большей позиции чем должен был быть.
        // к примеру, он находится на позиции y = 0, а velocity уменьшается всегда,
        // то при падении игрок резко перескочит на позиции velocity     
        if(IsGrounded && Velocity.y < 0)
        {
            Velocity.y = ZeroPointerVelocity;
           
        } 
        // гравитация delta y = 1/2 * g * t^2;
        Velocity.y += _gravity * Time.deltaTime;  
        Controller.Move(Velocity * Time.deltaTime);  
    }

    private  void JumpPlayer()
    {
        Velocity.y += Mathf.Sqrt(PlayerHeight * -2f * _gravity *Time.deltaTime);  
    }
     protected override void MovePlayer()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var move = transform.right * x + transform.forward * z;
        Controller.Move(move * SpeedPlayer * Time.deltaTime);
    }

     public override void CreatMagic(Magic _magic, Vector3 point)
    {
        var MagicBullet = Instantiate(_magic,_pointCreatMagic.position,Quaternion.identity);
        MagicBullet.gameObject.GetComponent<Rigidbody>().velocity = (point - _pointCreatMagic.position).normalized * 30f;
        Destroy(MagicBullet.gameObject,3f);
    }
} 
