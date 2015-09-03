using UnityEngine;
using System.Collections;

public abstract class Enemy : Entity
{
    protected IAI m_ai;
	protected Ability m_ability;
    public Transform target;
    public bool shouldAct { get { return target != null; }}
}
