using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    float FireRate  = 1f;
    float Timer = 0f;
    GameObject BulletPrefab;

    // Use this for initialization
    void Start()
    {
        BulletPrefab = Resources.Load("Bullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (Timer <= 0f)
            {
                Shoot();

                Timer = FireRate;// Mathf.Max(Timer + FireRate, 0);
            }
        }
    }

    void Shoot()
    {
        // TODO: unhackify
        var ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        var dir = ray.GetPoint(0) - transform.position;
        dir.z = 0;
        dir.Normalize();
        // instatiate bullet from this position...
        var newBulletGO = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
        var newBullet = newBulletGO.GetComponent<Bullet>();

//        newBullet.Initialize(dir);
    }
}
