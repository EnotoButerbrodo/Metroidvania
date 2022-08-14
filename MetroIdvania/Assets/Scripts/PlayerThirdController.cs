using UnityEngine;

sealed class PlayerThirdController : MonoBehaviour
{
    private Player _player => GetComponent<Player>() as Player;

    [SerializeField] private Magic _magic;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _point;

    [Tooltip("Время для нового выстрела")]
    [SerializeField] private float _reloadedFire; // 5;
    private float _timeToFire;

    private void Start()
    {
        _timeToFire = _reloadedFire;
    }
    private void Update()
    {
        //OnMouseDragPosition();
        PlayerAttack();
       
    }


    private void PlayerAttack()
    {
        if(Input.GetAxis("Fire1") == 1)
        {
            if(_timeToFire >= _reloadedFire)
            {
                _player.CreatMagic(_magic,OnMouseDragPosition());
                _timeToFire = 0;
            }
        } else 
        {
             _timeToFire += Time.deltaTime;
        }
    }
    private Vector3 OnMouseDragPosition()
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
       
       
        return pointToLook;  
    }

}
