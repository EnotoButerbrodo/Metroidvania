using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllerSpace
{
    sealed class Player_ThirdCamera : Player
    {
        private void Update()
        {
            LookMouse();
            GravityPlayer();
        }
        private void FixedUpdate()
        {
             MovePlayer();
        }

        private void LookMouse()
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var Ground = new Plane(Vector3.up,Vector3.zero);
            var LengthRay = 0f;
            var pointToLook = new Vector3();
            if(Ground.Raycast(Ray, out LengthRay))
            {
                pointToLook = Ray.GetPoint(LengthRay);
                Debug.DrawLine(Ray.origin,pointToLook,Color.red);
            }
            _playerBody.transform.LookAt(new Vector3
                (pointToLook.x,_playerBody.transform.position.y,pointToLook.z));
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
            Debug.DrawLine(_pointCreatMagic.position, point,Color.blue);
            point.y = _pointCreatMagic.position.y;
            Debug.DrawLine(_pointCreatMagic.position, point,Color.black);
            MagicBullet.gameObject.GetComponent<Rigidbody>().velocity = (point - _pointCreatMagic.position).normalized * 30f;
            Destroy(MagicBullet.gameObject,3f);
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

    }
}

