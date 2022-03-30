using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static event EventHandler PlayerOnHit;

    protected float speed,low_speed,normal_speed;
    protected Animator anime;
    protected sbyte x, y;
    protected Rigidbody2D rigid;
	
    protected void set(float s)
	{
		speed = s;
        normal_speed = s;
		low_speed = s * 0.6f;
	}

	// Start is called before the first frame update
	void Start()
    {
		
	}
	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			x = 1;
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			x = -1;
		}
		else { x = 0; }
		if (Input.GetKey(KeyCode.UpArrow))
		{
			y = 1;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			y = -1;
		}
		else { y = 0; }
		rigid.velocity = speed * (Vector2.up * y + Vector2.right * x);
		if (Input.GetKey(KeyCode.LeftShift))
		{
			speed = low_speed;
		}
		else
		{
			speed = normal_speed;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy")
		{
			anime.SetTrigger("hit");
			PlayerOnHit(this, EventArgs.Empty);
			Time.timeScale = 0;
		}
	}
}
