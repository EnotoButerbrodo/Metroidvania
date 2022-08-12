using UnityEngine;

namespace PlayerControllerSpace
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player _player => GetComponent<Player>();
        [SerializeField] private Magic _magic;
        [SerializeField] private float _reloadedFire; // 5;
        [SerializeField] private Camera _camera;
        private Vector3 point;
        private float _timeToFire;

        private void Start()
        {
             _timeToFire = _reloadedFire;
        }

        private void Update()
        {
           // ShootingTile();
        }

        private void ShootingTile()
        {
            if(Input.GetAxis("Fire1") == 1)
            {
                if( _timeToFire >= _reloadedFire)
                {
                    Ray Ray = _camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
                    RaycastHit hit;

                    if(Physics.Raycast(Ray, out hit))
                    {
                        point =  hit.point;
                    } else point = Ray.GetPoint(1000);

                    _player.CreatMagic(_magic, point);
                    _timeToFire = 0;
                }
            } else if(Input.GetAxis("Fire1") == 0)
            {
                _timeToFire += Time.deltaTime;
            }
        }
    }   
}
