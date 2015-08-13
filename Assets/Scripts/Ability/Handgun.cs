using UnityEngine;
using System.Collections;

public class Handgun : Ability
{
	public GameObject bullet;
	public float bulletSpeed = 1f;

	protected override void Shoot(Transform target)
	{
		GameObject newBullet = (GameObject)Instantiate(bullet, this.transform.position, transform.rotation);
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
