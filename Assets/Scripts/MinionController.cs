using System.Security.Cryptography;
using UnityEngine;
using System.Collections;

public class MinionController : MonoBehaviour
{
    public Transform Target;

    public float Acceleration = 15.0f;
    public float MinDistance = 1.0f;

    private float xMovement = 0;
    private float yMovement = 0;

    private Vector2 axis = Vector2.up;
    private const float rotationSpeed = 20f;


    private DistanceJoint2D dj;
    private Rigidbody2D rb;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dj = GetComponent<DistanceJoint2D>();
        dj.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Vector2 diff = Target.position - transform.position;
        var distance = diff.magnitude;
        if (distance > MinDistance)
        {
            var target = Target.position + 
                (Vector3.Cross(diff, Vector3.forward).normalized * MinDistance) ;
            diff = Target.position - transform.position;
            rb.AddForce(diff.normalized * Acceleration);
            dj.enabled = false;
        }
        else
        {
            dj.enabled = true;
            rb.AddForce(Vector3.Cross(diff, Vector3.forward) * rotationSpeed);
            
        }
    }
}
