using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Handgun : Ability
{
	public GameObject bullet;
	public float bulletSpeed = 1f;

	protected override void Shoot(Transform target)
	{
        Shoot(target.position);
	}
	
    protected override void Shoot(Vector3 target)
    {
        bullet.GetComponent<Bullet>().damage = 1f;
        Vector3 direction = (target - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = ((target - transform.position).normalized * bulletSpeed);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        bullet.transform.position = this.transform.position + direction * 0.5f;
        bullet.transform.rotation = this.transform.rotation;
        NetworkServer.Spawn(bullet);
    }

	protected override void Start()
	{
		MaxRange = 3;
		MinRange = 1;
		Cooldown = 1;
		base.Start();
	}
}
