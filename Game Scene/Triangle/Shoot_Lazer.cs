using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Lazer : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        set(70);
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = Vector2.up * speed;
    }
}
