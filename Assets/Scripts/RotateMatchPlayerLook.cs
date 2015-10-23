using UnityEngine;
using System.Collections;

public class RotateMatchPlayerLook : MonoBehaviour {

    private PlayerActionEvents events;

	// Use this for initialization
    void Start()
    {
        events = transform.parent.gameObject.GetComponent<PlayerActionEvents>();
        events.lookDirectionChange += onMoveDirectionChange;
    }
	
	// Update is called once per frame
    void onMoveDirectionChange(Quaternion lookDirection)
    {
        transform.rotation = lookDirection;

    }

    void Destroy()
    {

    }

}
