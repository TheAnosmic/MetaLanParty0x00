using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField] float lifespan;
    [SerializeField] public float damage;

    private AudioSource hitSound;

    void Start()
    {
        Destroy(gameObject, lifespan);
        hitSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return damage;
    }
    
    void OnDestroy()
    {
        if (null != hitSound)
        {
            AudioSource.PlayClipAtPoint(hitSound.clip, transform.position);
        }
    }

}
