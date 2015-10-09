using System;
using UnityEngine;
using System.Collections;

public class PlayerActionEvents : MonoBehaviour {

    public delegate void PlayerLookDirection(Quaternion look);
    public event PlayerLookDirection lookDirectionChange;

    public delegate void PlayerMoveDirection(float xMovement, float yMovement);
    public event PlayerMoveDirection moveDirectionChange;

    void Update()
    { 
        Quaternion lookAt = _2DHelper.LookAt(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (lookDirectionChange != null) lookDirectionChange(lookAt);

        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
        if (moveDirectionChange != null) moveDirectionChange(xMovement, yMovement);

    }
}
