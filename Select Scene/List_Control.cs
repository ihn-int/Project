using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class List_Control : MonoBehaviour
{
    public GameObject[] List = new GameObject[3];
    Vector3 pad = new Vector3(50, 0, 0);

    bool moving, direct;
    int delayTime=20,time;
    byte order,max;
    // Start is called before the first frame update

    void Start()
    {
        moving = false;
        order = 0;
        time = 0;
        max = (byte)(List.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
		if (!moving)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (order < max)
				{
                    moving = true;
                    direct = true;
                    order++;
                    time = delayTime;
				}
			}
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (order > 0)
				{
                    moving = true;
                    direct = false;
                    order--;
                    time = delayTime;
				}
			}
			if (Input.GetKeyDown(KeyCode.Return))
			{
                database.type = order;
                SceneManager.LoadScene("Game Scene");
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
                SceneManager.LoadScene("Menu Scene");
			}
		}
		else
		{
            if (time > 0)
            {
                if (direct)
                {
                    transform.position -= pad;
				}
				else
				{
                    transform.position += pad;
				}
                time--;
			}
			else
			{
                moving = false;
			}
		}
    }
}
