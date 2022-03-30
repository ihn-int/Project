using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("MyScript/Enemy2")]
public class Enemy2 : Enemy
{
    int b = 2, s = 7, t = 2;
    
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
