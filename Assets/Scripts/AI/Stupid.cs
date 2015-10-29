using UnityEngine;
using System.Collections;

class Stupid : IAI
{
    public Transform Target { get; set; }
    public double range;

    public Stupid(Transform target, double range)
    {
        this.Target = target;
        this.range = range;
    }

    public bool ShouldAttack(Vector3 currentPosition)
    {
        if (Target == null)
        {
            return false;
        }
        if (Vector3.Distance(currentPosition, Target.position) < range)
        {
            return true;
        }
        return false;
    }

    public Vector3 GetWalkDestination()
    {
        return Target.position;
    }

}