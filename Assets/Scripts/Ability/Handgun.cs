using UnityEngine;
using System.Collections;

public class Handgun : Ability
{
	public GameObject bullet;
	public float bulletSpeed = 1f;


    protected override void Shoot(Vector3 target)
    {
        GameObject newBullet = (GameObject)Instantiate(bullet, this.transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = ((target - transform.position).normalized * bulletSpeed);
        Physics2D.IgnoreCollision(newBullet.GetComponent<Collider2D>(), transform.parent.parent.GetComponent<Collider2D>());
    }

	protected override void Start()
	{
		MaxRange = 3;
		MinRange = 1;
		Cooldown = 0.1f;
	    bullet.GetComponent<Bullet>().damage = 1f;
		base.Start();
	}
}
