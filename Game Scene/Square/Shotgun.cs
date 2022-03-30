using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Bullet
{
    Vector2 direct;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        set(35);
        rigid = GetComponent<Rigidbody2D>();
        z = transform.rotation.z;
        direct = new Vector2(-Mathf.Sin(z), Mathf.Cos(z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = direct * speed;
    }
}
