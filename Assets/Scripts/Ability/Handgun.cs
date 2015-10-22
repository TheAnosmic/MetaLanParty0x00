using UnityEngine;
using System.Collections;

public class Handgun : Ability
{
	public GameObject bullet;
	public float bulletSpeed = 1f;


    protected override void Shoot(Vector3 target)
    {
        bullet.GetComponent<Bullet>().damage = 1f;
        Vector3 direction = (target - transform.position).normalized;
        GameObject newBullet = (GameObject)Instantiate(bullet, this.transform.position + direction * 0.5f, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = ((target - transform.position).normalized * bulletSpeed);
        Physics2D.IgnoreCollision(newBullet.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
    }

	protected override void Start()
	{
		MaxRange = 3;
		MinRange = 1;
		Cooldown = 0.1f;
		base.Start();
	}
}
