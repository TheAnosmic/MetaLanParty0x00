using UnityEngine;
using System.Collections;


public abstract class Ability : MonoBehaviour
{
	private float cooldownTimer;
	
	protected float MaxRange { get; set; }
	protected float MinRange { get; set; }
	protected float Cooldown { get; set; }

	public void Execute(Transform target)
	{
		if (cooldownTimer == 0) {
			Shoot(target);
			this.cooldownTimer = this.Cooldown;
		}
	}

	protected abstract void Shoot(Transform target);

	public void Start() 
	{
		this.cooldownTimer = this.Cooldown;
	}

	public void Update() 
	{
		cooldownTimer -= 1 * Time.deltaTime;
		if (cooldownTimer < 0) {
			cooldownTimer = 0;
		}
	}
}
