
using UnityEngine;
public class Magic : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.GetComponent<ITakeDamage>() != null) 
            col.gameObject.GetComponent<ITakeDamage>().Damage(1);

        Destroy(gameObject);
    }
}

