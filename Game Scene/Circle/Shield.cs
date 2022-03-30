using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Rigidbody2D rigid;

    int time = 3;
    int coldtime = 10;
    bool stand;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        stand = false;
        t = 0;
        rigid = GetComponent<Rigidbody2D>();
    }

	private void FixedUpdate()
	{
        if (!stand) 
        {
            if (t < coldtime)
            {
                rigid.velocity = Vector2.up * 20f;
                t++;
			}
			else
			{
                
                t = 0;
                stand = true;
			}
		}
		else
		{
            t += Time.deltaTime;
            rigid.velocity = Vector2.zero;
            if (t >= time)
			{
                Destroy(gameObject);
			}
		}
	}
}
