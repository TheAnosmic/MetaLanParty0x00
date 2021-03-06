using UnityEngine;
using System.Collections;


public abstract class Ability : MonoBehaviour
{
	private float cooldownTimer;

    public delegate void OnCooldownChange(float before, float after);

    public event OnCooldownChange onCoolDownChange;

	protected float MaxRange { get; set; }
	protected float MinRange { get; set; }
	public float Cooldown { get; protected set; }

    private AudioSource executeSource;

    protected virtual void Start()
    {
        executeSource = GetComponent<AudioSource>();

        cooldownTimer = Cooldown;
    }

    private void playExecuteSound()
    {
        if (null != executeSource)
        {
            executeSource.pitch = Random.Range(0.9f, 1.1f);
            executeSource.Play();
        }
    }
	
	public void Execute(Vector3 target)
    {
        if (CanExecute())
        {
            playExecuteSound();
            Shoot(target);
            cooldownTimer = Cooldown;
        }
    }

	
    public bool CanExecute()
    {
        return cooldownTimer < Mathf.Epsilon;
    }

    protected abstract void Shoot(Vector3 target);

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
