using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Fire : PlayerFire
{
    public static event EventHandler OnUlti;
    public GameObject shield;
    GameObject o;

    void Shield()
	{
        o = Instantiate(shield, transform.position+fixedVector3, q);
	}

	protected override void Fire()
	{
        g = Instantiate(bullet, transform.position + fixedVector3, q) as GameObject;
        time = coldtime;
        l.transform.localScale = linkV;
    }

	// Start is called before the first frame update
	void Awake()
    {
        set(0.8f,new Vector3(0,1.5f,0));
        l = Instantiate(link, gameObject.transform);
        l.transform.localPosition = new Vector2(0, -1.2f);
        l.transform.localScale = linkV;
    }
    
    private void FixedUpdate()
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
        if (Input.GetKeyDown(KeyCode.Z) && !BombController.ulti)
        {
            Shield();
            OnUlti(this, EventArgs.Empty);
        }
    }
}
