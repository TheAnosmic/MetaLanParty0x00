using UnityEngine;
using System.Collections;
using System;

public class LifeBar : MonoBehaviour, IHPChangeListener {
    
    public float startHP;
    private float startScaleX;
	// Use this for initialization
	void Start () {
        Entity parent = GetComponentInParent<Entity>();
        startHP = parent.hp;
        parent.HPListeners.Add(this);
	}

    public void OnHpChange(float oldHP, float newHP)
    {
        float xRatio = newHP / startHP;
        Vector3 scale = transform.localScale;

        scale.x *= xRatio;
        if (float.IsInfinity(scale.x))
        {
            return;
        }
        Debug.Log(transform.localScale);
        transform.localScale = new Vector3(.3f, 0, 0);
    }
}
