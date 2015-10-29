using UnityEngine;
using System.Collections;

public class FillFloor : MonoBehaviour {

    [SerializeField] GameObject floorTile;
    [SerializeField] float tileX;
    [SerializeField] float tileY;
    [SerializeField] int num;
    
    void Start () {

        float xOffset = tileX / 2;
        float yOffset = tileY / 2;

        for (int i = -num / 2; i < num / 2; i++)
        {
            for (int j = -num / 2; j < num / 2; j++)
            {
                var a = Instantiate(floorTile, 
                    new Vector3(
                        i * tileX + ((j % 2) * 0.35f) + xOffset, 
                        j * tileY + yOffset, 
                        floorTile.transform.position.z),
                    floorTile.transform.rotation) as GameObject;
                a.transform.parent = this.transform;
            }
        }
	}
	
}
