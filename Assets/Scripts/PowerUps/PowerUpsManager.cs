using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class PowerUpsManager : MonoBehaviour
    {
        private List<PowerUp> powerUps;
        private PowerUp prefab;

        public PowerUpsManager(PowerUp powerUpPrefab)
        {
            this.prefab = powerUpPrefab;
        }

        public void GeneratePowerUp()
        {
            var powerUp = Instantiate(prefab);
            powerUp.transform.position = new Vector3(-1.67f,-1.67f,-1.67f);
        }
    }
}
