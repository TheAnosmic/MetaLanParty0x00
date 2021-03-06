﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.PowerUps;

public class Map : MonoBehaviour {

    public Texture2D Background;
    public GameObject[] PossibleEnemies;
    public GameObject Player;
    public int maxEnemies;
    private EnemyFactory factory;
    private PowerUpsManager powerUpsManager;
    public PowerUp PowerUpPrefab;

	// Use this for initialization
	void Start () {
        factory = new EnemyFactory(gameObject);
        factory.PossibleEnemies = PossibleEnemies;
        factory.Target = Player;
        powerUpsManager = new PowerUpsManager(PowerUpPrefab);
        InvokeRepeating("Launch", 0.1f, 0.3F);
        // Create power up every 30 sec
        InvokeRepeating("CreatePrefab", 0.1f, 30F);
    }

    private void Launch()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            factory.Create(1, new Vector2(-10, -10), new Vector2(10, 10));
        }
        
    }

    void CreatePrefab()
    {
        // TODO: random location??
        this.powerUpsManager.GeneratePowerUp();
    }
}
