using UnityEngine;
using System.Collections;

public class _2DHelper {

    public static Quaternion LookAt(Transform who, Transform at)
    {
        var pos = Camera.main.WorldToScreenPoint(who.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
