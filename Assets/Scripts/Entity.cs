﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Entity : NetworkBehaviour {
    public float hp { get; protected set; }
    protected float armor;

    protected bool isAlive
    {
        get { return hp > 0; }
    }

    public delegate void HPChange(float beforehp, float afterhp);

    public event HPChange hpChange;
    // Use this for initialization
  
    protected void Start ()
    {
        hpChange += OnHpChange;
    }

    private void OnHpChange(float beforehp, float afterhp)
    {
        DamageTextCreator.Create(this, afterhp - beforehp);
    }

    // Update is called once per frame
	void Update () {
	}

    [ServerCallback]
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

    [ServerCallback]
    protected virtual void Die()
    {
        gameObject.SetActive(false);
        
        NetworkServer.Destroy(gameObject);
    }
}
