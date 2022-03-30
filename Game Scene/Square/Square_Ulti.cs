using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Ulti : MonoBehaviour
{
    public GameObject Ulti;
    GameObject g;
    Quaternion q = Quaternion.Euler(0, 0, 0);
    Vector3 fix = new Vector3(0, 0, 20);
    Quaternion f;

    void OnUlti(object o,EventArgs e)
	{
        
	}
	private void Awake()
	{
        Square_Fire.OnUlti += OnUlti;
	}
}
