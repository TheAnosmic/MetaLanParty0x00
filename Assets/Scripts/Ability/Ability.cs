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
		if (CanExecute()) 
		{
			Shoot(target);
			cooldownTimer = Cooldown;
		}
	}
	
	public void Execute(Vector3 target)
    {
        if (CanExecute())
        {
            Shoot(target);
            cooldownTimer = Cooldown;
        }
    }

	
    public bool CanExecute()
    {
        return cooldownTimer < Mathf.Epsilon;
    }

    protected abstract void Shoot(Transform target);
    protected abstract void Shoot(Vector3 target);

	protected virtual void Start() 
	{
		cooldownTimer = Cooldown;
	}

    protected virtual void Update() 
	{
		cooldownTimer -= 1 * Time.deltaTime;
		if (cooldownTimer < 0) {
			cooldownTimer = 0;
		}
	}
}
