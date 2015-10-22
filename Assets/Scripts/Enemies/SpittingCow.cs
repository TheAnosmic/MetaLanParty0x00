using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpittingCow : Enemy
{
    public Handgun gun;

    private bool moving;
    Animator animator;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
        moving = false;

        m_ai = new Stupid(target, 2);
        m_ability = gun;

        gun.bulletSpeed = 15;

        hp = 40;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = _2DHelper.LookAt(transform.position, target.position);
        if (!shouldAct)
        {
            return;
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
            animator.SetBool("isWalking", true);
            var dst = m_ai.GetWalkDestination();
            transform.position = Vector3.MoveTowards(transform.position, dst, 0.1f);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 0.48f);
        // Todo: set dying anim
        //animator.SetBool("isD");
    }
}
