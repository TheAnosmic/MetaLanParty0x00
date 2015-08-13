using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float lifespan;
    
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

}
