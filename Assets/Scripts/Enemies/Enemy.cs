using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    protected IAI m_ai;
	protected Ability m_ability;
    public Transform target;
}
