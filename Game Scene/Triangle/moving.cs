using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : Player
{

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        set(25);
	}
	// Update is called once per frame

}
