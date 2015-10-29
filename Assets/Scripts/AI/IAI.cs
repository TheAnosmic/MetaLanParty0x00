using UnityEngine;
using System.Collections;

public interface IAI
{
    bool ShouldAttack(Vector3 currentPosition);
    Vector3 GetWalkDestination();
    Transform Target { get; set; }
}