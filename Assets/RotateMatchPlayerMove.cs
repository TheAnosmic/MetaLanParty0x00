using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class RotateMatchPlayerMove : NetworkBehaviour
{
    private PlayerActionEvents events;
    Animator animator;

    void Start ()
    {
        animator = GetComponent<Animator>();
        events = transform.parent.gameObject.GetComponent<PlayerActionEvents>();
        events.moveDirectionChange += onMoveDirectionChange;
        //GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
        if (!isLocalPlayer)
        {
            //GetComponent<RotateMatchPlayerMove>().enabled = false;
        }
    }

    void onMoveDirectionChange(float xMovement, float yMovement)
    {
        if (xMovement == 0 && yMovement == 0)
        {
            animator.SetBool("isWalking", false);
            return;
        }
        animator.SetBool("isWalking", true);
        
        var angle = Mathf.Atan(yMovement/xMovement);
        float angleDeg = (180/Mathf.PI)*angle;

        // This makes it (270, 0, angleDeg). 
        // http://answers.unity3d.com/questions/481059/i-say-rotate-around-z-unity-rotates-around-y.html#comment-488024
        transform.rotation = Quaternion.Euler(new Vector3(-angleDeg, 90, 270));
    }

    void Destroy()
    {
        events.moveDirectionChange -= onMoveDirectionChange;
    }
}
