using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    const int size = 3;
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[size];
    public Image[] button = new Image[size];
    public TextMeshProUGUI demo;
    byte order;
    public Image point;

    Vector2 vec = new Vector2(0, 90);

    Color invisible;
    bool status;
    bool page;
    string play = "Press space to shoot bullet.\nPress left shift can low your speed.\n" +
            "Press z can use bomb.\nEscape key is for pause.";
    void demonstration(bool show)
	{
		if (show)
		{
            foreach(TextMeshProUGUI t in texts)
			{
                t.alpha = 0;
			}
            foreach(Image i in button)
			{
                invisible = i.color;
                invisible.a = 0;
                i.color = invisible;
			}
            invisible = point.color;
            invisible.a = 0;
            point.color = invisible;
            demo.alpha = 255;
		}
		else
		{
            foreach(TextMeshProUGUI t in texts)
			{
                t.alpha = 255;
			}
            foreach(Image i in button)
			{
                invisible = i.color;
                invisible.a = 255;
                i.color = invisible;
            }
            invisible = point.color;
            invisible.a = 255;
            point.color = invisible;
            demo.alpha = 0;
        }
	}
	private void Awake()
	{
        demo.text = play;
        status = false;
        demonstration(status);
	}

	// Start is called before the first frame update
	void Start()
    {
        point.rectTransform.anchoredPosition = new Vector2(-130, 90);
        order = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!status)
        {
			
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (order > 0)
                {
                    point.rectTransform.anchoredPosition += vec;
                    order--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (order < 2)
                {
                    point.rectTransform.anchoredPosition -= vec;
                    order++;
                }
            }
        }
        if (status) 
        {
            if(Input.GetKeyDown(KeyCode.Escape))
		    {
                status = false;
                demonstration(status);
            }
        }
        if(Input.GetKeyUp(KeyCode.Return))
        {
			if (order <= 2)
			{
                Debug.Log(order);
                //Destroy(btn);
				switch (order)
				{
                    case 0:
                        SceneManager.LoadScene("Select Scene");
                        break;
                    case 1:
                        status = true;
                        demonstration(status);
                        break;
                    case 2:
                        Application.Quit();
                        break;
                    default:
                        break;
				}
			}
		}
    }
    
}
