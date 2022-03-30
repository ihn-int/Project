using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_bullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        set(40);
        rigid = GetComponent<Rigidbody2D>();
    }
	private void Update()
	{
        rigid.velocity = Vector2.up * speed;
	}
}
