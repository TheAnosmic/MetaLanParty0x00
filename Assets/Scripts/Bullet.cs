using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Vector3 Dir;

    public void Initialize(Vector3 dir)
    {
        Dir = dir;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Dir * Time.deltaTime * 4);
    }
}
