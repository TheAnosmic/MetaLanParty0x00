using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public Texture2D Background;
    public GameObject[] PossibleEnemies;
    public GameObject Player;
    public int maxEnemies;
    private EnemyFactory factory;

	// Use this for initialization
	void Start () {
        factory = new EnemyFactory(gameObject);
        factory.PossibleEnemies = PossibleEnemies;
        factory.Target = Player;
        InvokeRepeating("Launch", 0.1f, 0.3F);

    }

    private void Launch()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            factory.Create(1, new Vector2(-10, -10), new Vector2(10, 10));
        }
    }
}
