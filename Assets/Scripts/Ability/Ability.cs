using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public abstract class Ability : NetworkBehaviour
{
	private float cooldownTimer;

    public delegate void OnCooldownChange(float before, float after);

    public event OnCooldownChange onCoolDownChange;

	protected float MaxRange { get; set; }
	protected float MinRange { get; set; }
	public float Cooldown { get; protected set; }

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
        float coolDownBefore = cooldownTimer;
		cooldownTimer -= 1 * Time.deltaTime;
		if (cooldownTimer < 0) {
			cooldownTimer = 0;
		    if (onCoolDownChange != null)
		    {
		        onCoolDownChange(cooldownTimer, cooldownTimer);
		    }
		}
	}
}
