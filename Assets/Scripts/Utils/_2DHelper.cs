using UnityEngine;
using System.Collections;

public class _2DHelper {

    public static Quaternion LookAt(Vector3 who, Vector3 at)
    {
        Vector3 diff = at - who;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
