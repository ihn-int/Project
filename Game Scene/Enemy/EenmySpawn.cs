using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EenmySpawn : MonoBehaviour
{
    int l;
    int r;
    public GameObject[] enemy=new GameObject[3];
    GameObject g;
    float coldtime;
    float RMx, Rmx,x,y=12.5f;
    float low, high;
    byte kind;
    Vector2 pos;
    Quaternion q = Quaternion.Euler(0, 0, 0);
    // Start is called before the first frame update
    void setTime(object o,EventArgs e)
	{
		if (l <= 2)
		{
            l++;
            Debug.Log("Level Up");
            low -= 0.02f;
            high -= 0.03f;
		}
	}
    void Start()
    {
        low = 0.1f;
        high = 0.3f;
        l = 1;
        RMx = 0.7f;
        Rmx = -16.2f;
    }
    void Spawn()
	{
        x = UnityEngine.Random.Range(Rmx, RMx);
        pos = new Vector2(x, y);
        r = UnityEngine.Random.Range(0, l);
        g = Instantiate(enemy[r], pos, q) as GameObject;

	}
	private void Awake()
	{
        UIHandler.UpdateLevelEvent += setTime;
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		if (coldtime <= 0)
		{
            coldtime = UnityEngine.Random.Range(low, high);
            Spawn();
		}
		else
		{
            if (coldtime >= 0)
            {
                coldtime -= Time.fixedDeltaTime;
            }
		}
    }
}
