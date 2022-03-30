using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Fire : PlayerFire
{
    public static event EventHandler OnUlti;
    public GameObject ulti;
    Vector3 vec = new Vector3(0, 0, 20);
    Quaternion f;

    void Ulti() 
    {
        for (int i = 0; i < 36; i++)
        {
            f.eulerAngles = q.eulerAngles + i * vec;
            g = Instantiate(ulti, transform.position, f);
        }
    }


    override protected void Fire()
	{
        g = Instantiate(bullet, transform.position + fixedVector3, q) as GameObject;
        f.eulerAngles = q.eulerAngles + vec;
        g = Instantiate(bullet, transform.position + fixedVector3, f) as GameObject;
        f.eulerAngles = q.eulerAngles - vec;
        g = Instantiate(bullet, transform.position + fixedVector3, f) as GameObject;
        time = coldtime;
        l.transform.localScale = linkV;
    }
    // Start is called before the first frame update
    void Awake()
    {
        set(0.5f, new Vector3(0, 1.5f, 0));
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
            Ulti();
            OnUlti(this, EventArgs.Empty);
        }
    }
	// Update is called once per frame
	void Update()
    {
        
    }
}
