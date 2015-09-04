using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;

public class DamageTextCreator : MonoBehaviour
{
    public GameObject TextPrefab;
    public Canvas Canvas;

    public static void Create(Entity source, float damage)
    {
        var self = FindObjectOfType<DamageTextCreator>();
        var damageTextInstance = (GameObject)Instantiate(self.TextPrefab, Vector3.zero, Quaternion.identity);
        var text = damageTextInstance.GetComponent<Text>();
        text.text = damage.ToString(CultureInfo.InvariantCulture);
        text.transform.SetParent(self.Canvas.transform);
        text.transform.position = source.transform.position + Vector3.up*0.5f;
    }
}
