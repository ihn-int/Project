using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScript : MonoBehaviour
{
    public GameObject[] Player = new GameObject[3];
    GameObject g;
	private void Awake()
	{
        g = Instantiate(Player[database.type], new Vector2(-14.5f, -11f), Quaternion.Euler(0, 0, 0));
	}


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
