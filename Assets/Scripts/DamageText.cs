using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private const float TotalTime = 1;

    void Start ()
    {
        transform.localScale = Vector3.one;
        Destroy(gameObject, TotalTime);
	}
	void Update ()
	{
	    var localTransform = transform.position;
	    localTransform.y += Time.deltaTime*1f;
	    transform.position = localTransform;
        var color = GetComponent<Text>().color;
        color.a -= Time.deltaTime / TotalTime;
	    GetComponent<Text>().color = color;
	}
}
