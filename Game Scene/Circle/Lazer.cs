using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : Bullet
{

    // Start is called before the first frame update
    void Start()
    {
        set(90);
        rigid = GetComponent<Rigidbody2D>();
    }
	private void FixedUpdate()
	{
        rigid.velocity = Vector2.up * speed;
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
