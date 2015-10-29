using System.Linq;
using UnityEngine;
using System.Collections;

public abstract class Enemy : Entity
{
    protected IAI m_ai;
    protected Ability m_ability;
    public Transform target;
    public bool shouldAct
    {
        get
        {
            if (target == null)
            {
                var a = FindNearestTarget();
                if (a != null)
                {
                    target = a.transform;
                    OnTargetChanged(target);
                }
            }
            return target != null;
        }
    }

    public virtual GameObject FindNearestTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        return players.FirstOrDefault();
    }

    public void OnTargetChanged(Transform t)
    {
        m_ai.Target = t;
    }

}
