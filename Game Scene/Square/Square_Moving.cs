using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Moving : moving
{
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        set(20);
    }
}
