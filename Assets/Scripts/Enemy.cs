using UnityEngine;
using System.Collections;

enum Action
{
    WALK, ATTAK
}

interface IAI
{
    bool ShouldAttack(Vector3 currentPosition);
    Vector3 GetWalkDestination();
    Transform GetTarget();
}

abstract class Ability
{
    public Ability(float maxRange, float minRange, float cooldown) 
	{
		this.MaxRange = maxRange;
		this.MinRange = minRange;
		this.Cooldown = cooldown;
	}

    private float MaxRange { get; set; }
    private float MinRange { get; set; }
    private float Cooldown { get; set; }

    public abstract void Execute(Transform target);
}


class Stupid : IAI
{

    private Transform t;
    public double range;

    public Stupid(Transform t, double range)
    {
        Debug.Log("Ctor");
        this.t = t;
        this.range = range;
    }

    public bool ShouldAttack(Vector3 currentPosition)
    {
        if (Vector3.Distance(currentPosition, t.position) < range)
        {
            return true;
        }
        return false;
    }

    public Vector3 GetWalkDestination()
    {
        Transform target = GetTarget();
        return target.position;
    }

    public Transform GetTarget()
    {
        return this.t;
    }

    public void Attack()
    {
        GameObject newBullet = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.MoveTowards(this.transform.position, target.transform.position, 0.01f);
    }
}



public class Enemy : MonoBehaviour
{

    private IAI m_ai;
    public Transform target;
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {
        m_ai = new Stupid(target, 2);

    }

    void Shoot()
    {
        GameObject newBullet = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.MoveTowards(this.transform.position, target.transform.position, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = m_ai.GetWalkDestination();
        if (m_ai.ShouldAttack(this.transform.position))
        {
            Shoot();
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, v, 0.1f);
        }
    }
}
