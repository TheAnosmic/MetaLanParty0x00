using UnityEngine;
using System.Collections;

class Stupid : IAI
{
	private Transform target;
	public double range;
	
	public Stupid(Transform target, double range)
	{
		this.target = target;
		this.range = range;
	}
	
	public bool ShouldAttack(Vector3 currentPosition)
	{
		if (Vector3.Distance(currentPosition, target.position) < range)
		{
			return true;
		}
		return false;
	}
	
	public Vector3 GetWalkDestination()
	{
		Transform target = GetTarget();
		return target.position;
	}
	
	public Transform GetTarget()
	{
		return this.target;
	}
	
}