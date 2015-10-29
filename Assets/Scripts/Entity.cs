using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Entity : NetworkBehaviour
{
    public float hp { get; protected set; }
    protected float armor;

    [SerializeField]
    AudioClip hitAudioClip;
    [SerializeField]
    AudioClip dieAudioClip;

    protected bool isAlive
    {
        get { return hp > 0; }
    }

    public delegate void HPChange(float beforehp, float afterhp);

    public event HPChange hpChange;

    protected void Start()
    {
        hpChange += OnHpChange;
    }

    private void OnHpChange(float beforehp, float afterhp)
    {
        DamageTextCreator.Create(this, afterhp - beforehp);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        var damagable = other.GetComponent<IDamageable>();
        if (damagable != null)
        {
            var oldHP = hp;
            hp -= damagable.GetDamage();
            if (hpChange != null) hpChange(oldHP, hp);
            if (hp > 0)
            {
                if (hitAudioClip != null)
                {
                    AudioSource.PlayClipAtPoint(hitAudioClip, transform.position);
                }
            }
            else
            {
                if (dieAudioClip != null)
                {
                    AudioSource.PlayClipAtPoint(dieAudioClip, transform.position);
                }
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
