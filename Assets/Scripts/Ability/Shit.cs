using UnityEngine;
using System.Collections;

public class Shit : MonoBehaviour, IDamageable
{
    public float damage;
    private uint shotsRemaining;
    private Collider2D collider;

    void Awake()
    {
        shotsRemaining = 3;
        collider = GetComponent<Collider2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        shotsRemaining--;
        if (shotsRemaining == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            collider.enabled = false;
            StartCoroutine(resetCollider());
        }
    }

    private IEnumerator resetCollider()
    {
        yield return new WaitForSeconds(1);
        collider.enabled = true;
    }
    
    public float GetDamage()
    {
        return damage;
    }
}
