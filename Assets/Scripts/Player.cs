using UnityEngine;
using System.Collections;

public class Player : Entity
{
    public float speed = 10.0f;
    public float bulletSpeed = 1.0f;
    public Handgun gun;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
        if (Input.GetButtonDown("Fire1"))
        {
            transform.rotation = _2DHelper.LookAt(this.transform, Camera.main.transform);
            

            //            // TODO: give the bullet the ability to move, rotate the player towards the mouse and create a bullet. The bullet should than move by it's own.
            //            Debug.Log("Player.FixedUpdate: Input.mousePosition = " + (Input.mousePosition));
            //            Debug.Log("Player.FixedUpdate: GetComponent<Rigidbody2D>().transform.position = " + (GetComponent<Rigidbody2D>().transform.position));
            //            Debug.Log("Player.FixedUpdate: originAngle = " + (originAngle));
            //            originAngle.z = 0;
            //            originAngle.Normalize();
            //            Debug.Log("Player.FixedUpdate: originAngle = " + (originAngle));
            //            var bulletOrigin = originAngle * (GetComponent<CircleCollider2D>().radius + /*bullet.GetComponent<CircleCollider2D>().radius+*/1);
            //            Debug.Log("Player.FixedUpdate: bulletOrigin = " + (bulletOrigin));


            /*GameObject instantiatedProjectile = Instantiate(bullet,
                                                           transform.position + bulletOrigin,
                                                           transform.rotation)
                as GameObject;
            Debug.Log("Player.FixedUpdate: instantiatedProjectile = " + (instantiatedProjectile != null));

            if (instantiatedProjectile != null)
        {
                instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = originAngle * bulletSpeed;
                Debug.Log("Player.FixedUpdate: instantiatedProjectile.velocity = " + instantiatedProjectile.GetComponent<Rigidbody2D>().velocity);
            }*/
        }
        }

    void FixedUpdate()
        {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
        if (true)// max speed 
        {
            var movement = new Vector2(xMovement, yMovement);
            rb.velocity = movement*speed;
        }
        //        
//
//        GetComponent<Rigidbody2D>().velocity = movement*speed;

    }


}
