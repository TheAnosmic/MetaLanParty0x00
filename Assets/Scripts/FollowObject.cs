using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FollowObject : MonoBehaviour
{
    public GameObject target;
    public bool KeepDistance = true;

    private float _distance;

    public void AttachPlayer(GameObject player)
    {
        target = player;
        _distance = KeepDistance ? target.transform.position.z - transform.position.z : 0;
    }
	
	// Update is called once per frame
	void Update () {
	    if (null == target)
	    {
	        return;
	    }

        transform.position = new Vector3(
            target.transform.position.x,
            target.transform.position.y,
            target.transform.position.z - _distance);
    }
}
