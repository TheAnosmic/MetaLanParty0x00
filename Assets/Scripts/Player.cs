using UnityEngine;
using System.Collections;

public class Player : Entity
{
    public float speed = 10.0f;
    public Handgun gun;
	
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 50;
        armor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _2DHelper.LookAt(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 toShoot = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
            toShoot = Camera.main.ScreenToWorldPoint(toShoot);
            //z must be zero to avoid stupid things.
            toShoot.z = 0;
            
            gun.Execute(toShoot); 
        }
    }


    void FixedUpdate()
	{
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
		var movement = new Vector2(xMovement, yMovement);
		rb.velocity = movement * speed;
	}

}
