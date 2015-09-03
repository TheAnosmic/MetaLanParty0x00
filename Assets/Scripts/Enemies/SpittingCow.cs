using System;
using UnityEngine;
using System.Collections;

public class SpittingCow : Enemy
{
    public Handgun gun;

    private bool moving;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        moving = false;

        m_ai = new Stupid(target, 2);
        m_ability = gun;

        gun.bulletSpeed = 15;

        hp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldAct)
        {
            return;
        }
        if (m_ai.ShouldAttack(transform.position))
        {
            m_ability.Execute(target);
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
            transform.position = Vector3.MoveTowards(transform.position, dst, 0.1f);
        }
    }
}
