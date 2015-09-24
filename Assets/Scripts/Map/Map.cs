using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Map : NetworkBehaviour {

    public Texture2D Background;
    public GameObject[] PossibleEnemies;
    public GameObject Player;
    private EnemyFactory factory;

	// Use this for initialization

	[ServerCallback]
    void Start () {
        factory = new EnemyFactory(gameObject);
        factory.PossibleEnemies = PossibleEnemies;
        factory.Target = Player;
        InvokeRepeating("Launch", 0.1f, 0.3F);

    }

    [ServerCallback]
    void Launch()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 10)
        {
            factory.Create(1, new Vector2(-10, -10), new Vector2(10, 10));
        }
        
    }
    
}
