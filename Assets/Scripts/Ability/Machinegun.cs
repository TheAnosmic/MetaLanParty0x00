﻿using UnityEngine;
using System.Collections;

public class Machinegun : Ability
{
	public GameObject bullet;
	protected float bulletSpeed = 15f;

    protected override void Shoot(Vector3 target)
    {
        bullet.GetComponent<Bullet>().damage = 0.1f;
        Vector3 direction = (target - transform.position).normalized;
        GameObject newBullet = (GameObject)Instantiate(bullet, this.transform.position + direction * 0.5f, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = ((target - transform.position).normalized * bulletSpeed);
        Physics2D.IgnoreCollision(newBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

	protected override void Start()
	{
		MaxRange = 3;
		MinRange = 1;
		Cooldown = 0.1f;
        base.Start();
	}
}
