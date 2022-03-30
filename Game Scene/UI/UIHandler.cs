using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    static int highscore;
    public static event EventHandler UpdateLevelEvent;

    public Image bomb;
    public Image panel;
    public TextMeshProUGUI score;
    public TextMeshProUGUI level;
    public TextMeshProUGUI pause;
    public TextMeshProUGUI high;

    public Texture2D[] bomblist;
    public TextMeshProUGUI[] list;
    public Image point;
    bool death;
    byte order, count;
    Vector2 movement = new Vector2(0, 50);
    Color show = new Color(255, 255, 255, 255);
    Color hide = new Color(0, 0, 0, 0);
    void showUI(bool show, bool died)
    {
        if (!show)
        {
                //hide
            foreach (TextMeshProUGUI t in list)
            {
                t.alpha = 0;
            }
            point.color = hide;
            pause.alpha = 0;
        }
        else
        {
                //show
            if (died)
            {
                //died
                pause.text = $"Score:{int_s.ToString()}"; 
                if (this.int_s > highscore)
                {
                    highscore = this.int_s;
                    //ScoreWriter.Write(highscore.ToString());
                }
                high.text = $"High Score:\n{highscore.ToString("D6")}";
                int_s = 0;
            }
            else
            {
                pause.text = "Pause";
            }
            foreach (TextMeshProUGUI t in list)
            {
                t.alpha = 255;
            }
            point.color = this.show;
            pause.alpha = 255;
        }
    }
    void onhit(object o, EventArgs e)
    {
		//show & died
        escapePress = true;
        death = true;
        showUI(escapePress, death);
    }

    readonly string str_s = "score:", str_l = "level:", str_b = "bomb:";
    int int_s = 0, int_l = 1, int_c;
    bool escapePress;
    public void AddScore(object o, Enemy.OnHitEventArgs e)
    {
        int_s += 1 * e.b * 10;
        int_c += 1 * e.b * 10;
        UpdateScore();
    }
    void UpdateScore()
    {
        score.text = $"{str_s}{int_s.ToString("d6")}";
    }
    void UpdateLevel(object o, EventArgs e)
    {
        level.text = $"{str_l}{int_l}";
    }
    private void Awake()
    {
		switch (database.type)
		{
            case 0:
                moving.PlayerOnHit += onhit;
                break;
            case 1:
                Square_Moving.PlayerOnHit += onhit;
                break;
            case 2:
                Circle_Moving.PlayerOnHit += onhit;
                break;
        }
        showUI(false, false);
        count = (byte)(list.Length - 1);
        UpdateLevelEvent += UpdateLevel;
        Enemy.onHit += AddScore;
        escapePress = false;
        death = false;
        UpdateScore();
        UpdateLevel(this, EventArgs.Empty);
    }
    // Start is called before the first frame update
    void Start()
    {
        //highscore = int.Parse(ScoreWriter.Read());
        high.text = $"High Score:\n{highscore.ToString("D6")}";
        int_s = 0;
        int_c = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (int_c >= 1000)
        {
            int_l += 1;
            int_c = 0;
            UpdateLevelEvent(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!escapePress && !death)
            {
                escapePress = true;
                showUI(escapePress, death);
                Time.timeScale = 0;
            }
            else
            {
                escapePress = false;
                showUI(escapePress, death);
                Time.timeScale = 1;
            }
        }
        if (escapePress)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && order < count)
            {
                point.rectTransform.anchoredPosition -= movement;
                order++;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && order > 0)
            {
                point.rectTransform.anchoredPosition += movement;
                order--;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                switch (order)
                {
                    case 0:
                        SceneManager.LoadScene("Menu Scene");
                        break;
                    case 1:
                        SceneManager.LoadScene("Game Scene", LoadSceneMode.Single);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
