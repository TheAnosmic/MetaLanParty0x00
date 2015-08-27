using UnityEngine;
using System.Collections;

public class Mines : Ability
{
    public GameObject mine;
    
	// Use this for initialization
    protected override void Shoot(Transform target)
    {
        GameObject newMine = Instantiate(mine, transform.position, Quaternion.identity) as GameObject;
        Physics2D.IgnoreCollision(newMine.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void Awake()
    {
        MaxRange = 0;
        MinRange = 0;
        Cooldown = 3;
    }
    
	
}
