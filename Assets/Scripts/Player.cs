using UnityEngine;
using System.Collections;

public class Player : Entity
{
    public float speed = 10.0f;
    public float bulletSpeed = 1.0f;
    public Handgun gun;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        hp = 50;
        armor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _2DHelper.LookAt(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
        var movement = new Vector2(xMovement, yMovement);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

    }


}