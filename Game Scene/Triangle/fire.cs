using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : PlayerFire
{
    public static event EventHandler OnUlti;
    override protected void Fire()
    {
        g = Instantiate(bullet, transform.position + fixedVector3, q) as GameObject;
        time = coldtime;
        l.transform.localScale = linkV;
    }
	private void Awake()
	{
        set(0.1f, new Vector3(0, 1.5f, 0));
        l = Instantiate(link, gameObject.transform);
        l.transform.localPosition = new Vector2(0, -1);
        l.transform.localScale = linkV;
	}
    
    void FixedUpdate()
    {
        if (time <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Fire();
            }
        }
        else
        {
            if (time >= 0)
            {
                time -= Time.fixedDeltaTime;
                l.transform.localScale -= resize / coldtime * Time.fixedDeltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Z) && !BombController.ulti)
        {
            OnUlti(this, EventArgs.Empty);
        }
    }
}
