﻿using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class SpeedBoostPower : BasePowerUp
    {
        private float speedFactor;
        private Manipulation manipulation;
        private GameObject target;
        private float timeSpan;

        public override void Start(GameObject target, Transform sourceTransform) 
        {
            this.speedFactor = 30f;
            this.timeSpan = 15f;
            this.target = target;
            this.manipulation = new Manipulation() { Type = ManipulationType.ADD, Value = speedFactor };
            target.GetComponent<global::Player>().speed.AddManipulation(manipulation);
            Invoke("StopBoost", timeSpan);
        }

        void StopBoost()
        {
            target.GetComponent<global::Player>().speed.RemoveManipulation(manipulation);
            Destroy(gameObject);
        }
    }
}
