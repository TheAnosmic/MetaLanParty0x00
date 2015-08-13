using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IHPChangeListener {
    void OnHpChange(float oldHP, float newHP);
}

public class Entity : MonoBehaviour {
    public float hp { get; protected set; }
    protected float armor;

    public List<IHPChangeListener> HPListeners = new List<IHPChangeListener>();

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
            HPListeners.ForEach(listener => listener.OnHpChange(oldHP, hp));
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
