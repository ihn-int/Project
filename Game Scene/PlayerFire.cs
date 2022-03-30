using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerFire : MonoBehaviour
{
    public GameObject link;
    protected GameObject l;
    protected GameObject g;
    protected float time = 0;
    protected float coldtime;
    protected Quaternion q = Quaternion.Euler(0, 0, 0);
    protected Vector3 fixedVector3;
    protected Vector3 linkV = new Vector3(1.5f, 1, 0);
    protected Vector3 resize = new Vector3(1.5f, 0, 0);
    public GameObject bullet;

    protected void set(float ct,Vector3 fv)
	{
        coldtime = ct;
        fixedVector3 = fv;
	}
    protected virtual void Fire() { }
    // Start is called before the first frame update
    void Start()
    {
        
    }
	private void FixedUpdate()
	{
        
    }
	// Update is called once per frame
	void Update()
    {
        
    }
}
