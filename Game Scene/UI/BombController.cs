using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class BombController : MonoBehaviour
{
	RectTransform M_rect;
    public Image bomb;
    public Sprite[] bomblist;
	int ulticold, width = 100;
	float cold;
	Vector2 resize;
	public static bool ulti;
	void UpdateBomb(object o,EventArgs e)
	{
		ulti = true;
		cold = ulticold;
		if (M_rect != null)
		{
			M_rect.sizeDelta = new Vector2(width, width);
		}
		
	}
	private void Awake()
	{
		ulti = false;
		M_rect = gameObject.GetComponent<RectTransform>();
		bomb.sprite = bomblist[database.type];
		switch (database.type)
		{
			case 0:
				ulticold = 20;
				fire.OnUlti += UpdateBomb;
				break;
			case 1:
				ulticold = 25;
				Square_Fire.OnUlti += UpdateBomb;
				break;
			case 2:
				ulticold = 20;
				Circle_Fire.OnUlti += UpdateBomb;
				break;
			default:
				break;
		}
		resize = new Vector2(0, width / ulticold);
		M_rect.sizeDelta = Vector2.right;
	}
	private void FixedUpdate()
	{
		if (ulti && cold > 0)
		{
			M_rect.sizeDelta -= resize * Time.fixedDeltaTime;
			cold -= Time.fixedDeltaTime;
			if (cold <= 0)
			{
				ulti = false;
			}
		}
	}

}
