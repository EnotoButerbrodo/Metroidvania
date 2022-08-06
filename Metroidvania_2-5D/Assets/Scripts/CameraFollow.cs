using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpSpeed;

    private Vector3 _offset;

    private float _lerpValue;

    private void Awake() {
        _offset = transform.position - _target.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,  _target.position + _offset, _lerpSpeed);
    }

    
  
}
