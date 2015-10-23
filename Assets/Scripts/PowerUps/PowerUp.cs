using UnityEngine;
using System.Collections;
using Assets.Scripts.PowerUps;

public class PowerUp : Pickup
{

    public BasePowerUp[] PowerUps;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Generate random power up.
            Instantiate(PowerUps[Random.Range(0, PowerUps.Length)]).Start(other.gameObject, this.transform);
            Destroy(gameObject);
        }
    }
}

