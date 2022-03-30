using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreWriter : MonoBehaviour
{
    static StreamReader sr;
    static string strr;
    static StreamWriter sw;
    static string path;
    public static string Read()
	{
        sr = new StreamReader(path);
        strr = sr.ReadLine();
        sr.Close();
        return strr;
	}
    public static void Write(string highscore)
	{
        sw = new StreamWriter(path, false);
        sw.WriteLine(highscore);
        sw.Close();
	}

	private void Awake()
	{
        path = $"{Application.dataPath}\\game scene\\scorelist.txt";
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
