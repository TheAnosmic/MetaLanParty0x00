using UnityEngine;
using System.Collections;

public class Handgun : Ability
{
	public GameObject bullet;
	public float bulletSpeed = 1f;

	protected override void Shoot(Transform target)
	{
		GameObject newBullet = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
		newBullet.GetComponent<Rigidbody2D>().velocity = ((target.position - this.transform.position).normalized * bulletSpeed);
	}

	void Start()
	{
		this.MaxRange = 3;
		this.MinRange = 1;
		this.Cooldown = 1;
		base.Start();
	}

	void Update() 
	{
		base.Update();
	}
}
