using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour
{

    public GameObject target;
    public bool KeepDistance = true;

    private float distance;

	// Use this for initialization
	void Start ()
	{
	    distance = KeepDistance ? target.transform.position.z - transform.position.z : 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(
            target.transform.position.x,
            target.transform.position.y,
            target.transform.position.z - distance);
    }
}
