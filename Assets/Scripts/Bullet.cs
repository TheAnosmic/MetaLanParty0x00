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

    [ServerCallback]
    void OnTriggerEnter2D(Collider2D other)
    {
        NetworkServer.Destroy(gameObject);
    }

    public float GetDamage()
    {
        return damage;
    }

}
