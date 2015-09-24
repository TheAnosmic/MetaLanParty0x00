using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : Entity
{
    public float speed = 10.0f;

    protected Ability mAbility { get; set; }
	
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 200;
        armor = 0;
        mAbility = GetComponentInChildren<Ability>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _2DHelper.LookAt(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetButton("Fire1"))
        {
            Vector3 toShoot = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
            toShoot = Camera.main.ScreenToWorldPoint(toShoot);
            //z must be zero to avoid stupid things.
            toShoot.z = 0;
            
            mAbility.Execute(toShoot); 
        }
    }


    void FixedUpdate()
	{
        if (!true)
        {
            return;
        }

        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
		var movement = new Vector2(xMovement, yMovement);
		rb.velocity = movement * speed;
	}

    [ServerCallback]
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!true)
        {
            return;
        }

        if (other.gameObject.CompareTag("WeaponPickup"))
        {
            switchWeapon(other.gameObject.GetComponent<WeaponPickup>().weapon);
        }
        else
        {
            base.OnTriggerEnter2D(other);
        }
    }

    private void switchWeapon(GameObject newWeaponPrefab)
    {
        Destroy(mAbility.gameObject);
        GameObject newWeapon = Instantiate(newWeaponPrefab, transform.position, transform.rotation) as GameObject;
        newWeapon.transform.parent = transform;
        mAbility = newWeapon.GetComponent<Ability>();
        Debug.Log("Switched weapon");
    }

}
