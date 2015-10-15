using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    public Texture2D texture;

	// Use this for initialization
	void Start () {
        Vector2 hotspot = new Vector2(texture.width / 2, texture.height / 2);
        Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
