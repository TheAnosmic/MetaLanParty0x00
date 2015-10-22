using UnityEngine;
using System.Collections.Generic;

public class FillLights : MonoBehaviour {

    [SerializeField] GameObject lightsParent;
    [SerializeField] int rows;
    [SerializeField] int cols;
    [SerializeField] List<Color> colors;

    List<Light> lights;
    bool decresing;


	void Start () {

        lights = new List<Light>();
        for (int i = -rows / 2; i < rows / 2; i++)
        {
            for (int j = - cols / 2; j < cols / 2; j++)
            {
                GameObject lightHolder = new GameObject("LightHolder " + i + " " + j);
                lightHolder.transform.SetParent(lightsParent.transform);
                Light lightComp = lightHolder.AddComponent<Light>();
                lightComp.color = colors[Random.Range(0, colors.Count)];
                lightComp.intensity = 5;
                lightComp.range = 6;
                lightHolder.transform.position = new Vector3(i * 5, j * 5, 0.77f);
                lights.Add(lightComp);
            }
        }
	}

    void Update()
    {
        foreach(var i in lights)
        {
            if (decresing)
            {
                i.intensity -= 0.05f;
            }
            else
            {
                i.intensity += 0.05f;
            }
        }

        if (decresing && lights[0].intensity < 0.1f)
        {
            decresing = false;
        }
        else if(!decresing && lights[0].intensity > 5)
        {
            decresing = true;
        }
    }
	
}
