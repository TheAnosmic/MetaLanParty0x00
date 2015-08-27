﻿using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public Texture2D Background;
    public GameObject[] PossibleEnemies;
    public GameObject Player;
    private GameObject target;
    private EnemyFactory factory;

	// Use this for initialization
	void Start () {
        factory = new EnemyFactory(gameObject);
        factory.PossibleEnemies = PossibleEnemies;

        target = GameObject.Find("Target");
        factory.Target = target;
        InvokeRepeating("Launch", 2, 0.3F);
    }

    void Launch()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 10)
        {
            factory.Create(2, new Vector2(-10, -10), new Vector2(10, 10));
        }
        
    }
    
}
