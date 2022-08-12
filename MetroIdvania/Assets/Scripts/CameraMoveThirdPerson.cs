using UnityEngine;

sealed class CameraMoveThirdPerson : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private Vector3 offset;

    [SerializeField] [Range(-25,25)] private float _xOffset = 0;
    [SerializeField] [Range(-25,25)] private float _yOffset = 0;
    [SerializeField] [Range(-25,25)] private float _zOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - _target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = _target.transform.position + offset;
        transform.position = new Vector3(desiredPosition.x + _xOffset,
        desiredPosition.y + _yOffset, desiredPosition.z + _zOffset);
    }
}
