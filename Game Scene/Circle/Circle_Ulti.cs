using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Ulti : MonoBehaviour
{
    public GameObject shield;
    GameObject g;

    void OnUlti(object o,EventArgs e)
	{
        g = Instantiate(shield, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
	}

	private void Awake()
	{
        
	}
	// Start is called before the first frame update
	void Start()
    {
        Circle_Fire.OnUlti += OnUlti;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
