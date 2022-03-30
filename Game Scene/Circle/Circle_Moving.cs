using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Moving : Player
{
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        set(30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
