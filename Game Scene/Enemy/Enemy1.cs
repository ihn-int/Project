﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("MyScript/Enemy1")]
public class Enemy1 : Enemy
{
    int b = 1, s = 10, t = 1;
    
    private void Awake()
	{
        rigid = GetComponent<Rigidbody2D>();
        set(b, s, t);
    }

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = Vector2.down * dropSpeed;
    }
	
}
