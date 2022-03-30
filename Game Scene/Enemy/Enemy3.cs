using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("MyScript/Enemy3")]
public class Enemy3 : Enemy
{
    int b = 3, s = 5, t = 3;

    private void Awake()
    {
        set(b, s, t);
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = Vector2.down * dropSpeed;
    }
}
