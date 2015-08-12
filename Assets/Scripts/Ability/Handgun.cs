using UnityEngine;
using System.Collections;

public class Handgun : Ability
{
	public GameObject bullet;

	protected override void Shoot(Transform target)
	{
		GameObject newBullet = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
		newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.MoveTowards(this.transform.position, target.transform.position, 0.01f);
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
