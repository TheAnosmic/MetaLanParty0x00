using System;
using UnityEngine;
using System.Collections;

public class SlidingCow : Enemy
{
    public Handgun gun;

    private Rigidbody2D rb;
    private bool moving;
    private float m_velocity;
    private float m_maxSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    new void Start()
    {
        base.Start();
        moving = false;
        m_ai = new Stupid(target, 5);
        gun.bulletSpeed = 15;
        m_ability = gun;
        hp = 1;
        m_velocity = 5;
        m_maxSpeed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldAct)
        {
            moving = false;
        }
        if (m_ai.ShouldAttack(transform.position))
        {
            m_ability.Execute(target.position);
            moving = false;
        }
        else
        {
            moving = true;
        }
    }

    void FixedUpdate()
    {
        if (!shouldAct)
        {
            return;
        }
        if (moving)
        {    
            var dst = m_ai.GetWalkDestination();
            var velocity = Vector3.Normalize(dst - transform.position) * m_velocity;
            rb.AddForce(velocity);
            if (rb.velocity.magnitude > m_maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * m_maxSpeed;
            }
        }
        else
        {
            if (rb.velocity.magnitude < 0.01)
            {
                rb.velocity = Vector2.zero;
            }
            else
            {
                rb.velocity *= 0.9f;
            }
        }
    }
}
