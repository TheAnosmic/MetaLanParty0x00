using UnityEngine;
using System.Collections;
using System;

public class LifeBar : MonoBehaviour {
    
    public float startHP;
    private float startScaleX;

	// Use this for initialization
	void Start () {
        Entity parent = GetComponentInParent<Entity>();
        startHP = parent.hp;
        parent.hpChange += OnHpChange;
	    startScaleX = transform.localScale.x;
	}

    public void OnHpChange(float oldHP, float newHP)
    {
        float xRatio = newHP / startHP;
        Vector3 scale = transform.localScale;

        scale.x = startScaleX * xRatio;
        if (float.IsInfinity(scale.x))
        {
            return;
        }
        transform.localScale = scale;
    }
}
