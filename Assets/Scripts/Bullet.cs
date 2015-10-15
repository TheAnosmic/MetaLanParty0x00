using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour, IDamageable
{
    public float lifespan;
    public float damage;
    
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return damage;
    }

}
