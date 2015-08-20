using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour {
    public float hp { get; protected set; }
    protected float armor;

    public delegate void HPChange(float beforehp, float afterhp);

    public event HPChange hpChange;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        var damagable = other.GetComponent<IDamageable>();
        if (damagable != null)
        {
            var oldHP = hp;
            hp -= damagable.GetDamage();
            if (hpChange != null) hpChange(oldHP, hp);
            if (hp <= 0)
            {
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
