using UnityEngine;
using System.Collections;

public class Handgun : Ability
{
	public GameObject bullet;
	public float bulletSpeed = 1f;

	protected override void Shoot(Transform target)
	{
        bullet.GetComponent<Bullet>().damage = 1f;
        Vector3 direction = (target.position - transform.position).normalized;
        GameObject newBullet = (GameObject)Instantiate(bullet, this.transform.position + direction * 0.5f, transform.rotation);
		newBullet.GetComponent<Rigidbody2D>().velocity = ((target.position - transform.position).normalized * bulletSpeed);
	}

	protected override void Start()
	{
		MaxRange = 3;
		MinRange = 1;
		Cooldown = 1;
		base.Start();
	}
}
