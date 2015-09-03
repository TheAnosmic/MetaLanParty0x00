using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{

    public Slider HPBar;
    public Slider ReloadBar;

    private Entity target;

    void Awake()
    {
        target = GetComponent<Entity>();
    }

    void Start()
    {
        target.hpChange += OnHPChange;
        HPBar.maxValue = target.hp;
        HPBar.value = target.hp;
        /*
        Ability a = target.GetComponent<Ability>();
        a.onCoolDownChange += OnCooldownChange;
        ReloadBar.maxValue = a.Cooldown;
        ReloadBar.value = a.Cooldown;
         */

    }

    private void OnHPChange(float beforehp, float afterhp)
    {
        HPBar.value -= Mathf.Abs(afterhp - beforehp);
        if (afterhp <= 0)
        {
            HPBar.enabled = false;

        }
    }

    private void OnCooldownChange(float before, float after)
    {
        ReloadBar.value -= after - before;
    }

    void Destroy()
    {
        target.hpChange -= OnHPChange;
    }
}
