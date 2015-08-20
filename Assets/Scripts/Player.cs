using UnityEngine;
using System.Collections;

public enum Movement
{
    StandingStill = 0,
    Left = 1,
    Right = 2,
    Up = 3,
    Down = 4,
}

public class Player : Entity
{
    public Movement xMovement;
    public Movement yMovement;
    public Weapon weapon;

    // Use this for initialization
    void Start()
    {
        hp = 50;
        armor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Movement.StandingStill;
        yMovement = Movement.StandingStill;

        if (Input.GetKey(KeyCode.W))
        {
            yMovement = Movement.Up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yMovement = Movement.Down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xMovement = Movement.Left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xMovement = Movement.Right;
        }
//        GetComponent<Animator>().SetInteger("Direction", (int)xMovement);
        //if (yMovement != Movement.StandingStill)
        //    GetComponent<Animator>().SetInteger("Direction", (int)yMovement);
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2(0, 0);

        if (yMovement == Movement.Up)
        {
            move.y += 1;
        }
        else if (yMovement == Movement.Down)
        {
            move.y -= 1;
        }

        if (xMovement == Movement.Right)
        {
            move.x += 1;
        }
        else if (xMovement == Movement.Left)
        {
            move.x -= 1;
        }

        move.Normalize();
        move = move * 0.1f;
        transform.Translate(move.x, move.y, 0);

    }


}
