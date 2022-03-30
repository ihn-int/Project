using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event EventHandler<OnHitEventArgs> onHit;
    public partial class OnHitEventArgs : EventArgs
    {
        public int b;
        public OnHitEventArgs(int b_)
        {
            b = b_;
        }
    }
    protected void set(int b, int s,int t)
    {
        o = new OnHitEventArgs(b);
        dropSpeed = s;
        times = t;
    }
    protected int dropSpeed, times;
    protected Rigidbody2D rigid;

    protected OnHitEventArgs o;

	private void Awake()
	{
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            times--;
            if (times == 0)
            {
                onHit(this, o);
                Destroy(gameObject);
            }
        }
        else if (collision.tag == "Lazer")
		{
            onHit(this, o);
            Destroy(gameObject);
		}
        else if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
