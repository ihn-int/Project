using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public GameObject ulti;
    GameObject g;
    const int times = 20, coldtime = 5;
    int t,c;
    public static bool onFire;
    Vector3 vec = new Vector2(0, 1.5f);
    Vector3 spawn,fixedVec;
    float x;
    
    void Ulti(object o,EventArgs e)
	{
        c = 30;
        onFire = true;
	}
	private void Awake()
	{
        fire.OnUlti += Ulti;
	}
    private void FixedUpdate()
    {
            if (c > 0)
            {
                if (t == 0)
                {
                    spawn = transform.position;
                    x = UnityEngine.Random.Range(-1.5f, 1.5f);
                    fixedVec = new Vector2(x, 0.5f);
                    spawn += fixedVec;
                    g = Instantiate(ulti, spawn, Quaternion.Euler(0, 0, 0)) as GameObject;
                    t = coldtime;
                    c--;
                }
                else
                {
                    t--;
                }
			}
			else
			{
                onFire = false;
			}
        
	}
	// Start is called before the first frame update
	void Start()
    {
        t = 0;
        c = 0;
    }
}
