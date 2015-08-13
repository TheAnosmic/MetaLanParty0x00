using UnityEngine;
using System.Collections;

public class SpittingCow : Enemy
{
    public Handgun gun;

    // Use this for initialization
    void Start()
    {
        m_ai = new Stupid(target, 2);
        gun.bulletSpeed = 15;
        m_ability = gun;
        hp = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_ai.ShouldAttack(transform.position))
        {
            m_ability.Execute(target);
        }
        else
        {
            Vector3 v = m_ai.GetWalkDestination();
            transform.position = Vector3.MoveTowards(transform.position, v, 0.1f);
        }
    }
}
