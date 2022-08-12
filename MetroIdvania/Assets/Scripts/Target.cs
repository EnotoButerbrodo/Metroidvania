using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour, ITakeDamage
{

    [SerializeField] private ParticleSystem _partical;
    [SerializeField] private float _live;
    [SerializeField] private Material _deathMaterial;
    private float _damage;

    public void Damage(int damage)
    {
        _live -= damage;
        if(_live <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().material = _deathMaterial;
            Destroy(gameObject,2);
        }
        _partical.Play();
    }


    private IEnumerator FireTime()
    {
        _partical.Play();
        yield return new WaitForSeconds(3f);
        _partical.Stop();
    }
}
