using UnityEngine;
using System.Collections;

public class FillFloor : MonoBehaviour {

    [SerializeField] GameObject floorTile;
    [SerializeField] float tileX;
    [SerializeField] float tileY;
    [SerializeField] int num;
    
    void Start () {
        for (int i = -num / 2; i < num / 2; i++)
        {
            for (int j = -num / 2; j < num / 2; j++)
            {
                var a = Instantiate(floorTile, 
                    new Vector3(
                        i * tileX + ((j % 2) * 0.35f), 
                    j * tileY, 
                    floorTile.transform.position.z),
                    floorTile.transform.rotation) as GameObject;
                a.transform.parent = this.transform;
            }
        }
	}
	
}
