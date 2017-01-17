using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManagerScript : MonoBehaviour {
    [SerializeField]
    private Camera cam1;
    [SerializeField]
    private Camera cam2;
    [SerializeField]
    private Camera cam3;

    public bool PlayEnd;
    public float Limit_Time = 120f;
    public UILabel TimeLabel;
    public GameObject GUI;
    public UILabel FinalMessage;


	// Use this for initialization
	void Start () {
        TimeLabel.text = string.Format("Time : {0:N2}", Limit_Time);
        Physics.gravity = new Vector3(0, -20.0F, 0);
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayEnd != true)
        {
            if (Limit_Time > 0)
            {
                Limit_Time -= Time.deltaTime;
                TimeLabel.text = string.Format("Time : {0:N2}", Limit_Time);
            }
            else
            {
                GameOver();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(cam1.enabled)
            {
                cam1.enabled = !cam1.enabled;
                cam2.enabled = !cam2.enabled;
            }
            else if(cam2.enabled)
            {
                cam3.enabled = !cam3.enabled;
                cam2.enabled = !cam2.enabled;
            }
            else if (cam3.enabled)
            {
                cam1.enabled = !cam1.enabled;
                cam3.enabled = !cam3.enabled;
            }
        }
	}
    
    public void Clear()
    {
        if(PlayEnd != true)
        {
            Time.timeScale = 0;
            PlayEnd = true;
            FinalMessage.text = "Clear!!";
            GUI.SetActive(true);
        }
    }

    public void GameOver()
    {
        if (PlayEnd != true)
        {
            Time.timeScale = 0;
            PlayEnd = true;
            FinalMessage.text = "Fail...";
            GUI.SetActive(true);
        }
        
    
    }

    public void Replay1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map1");
    }

    public void Replay2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map2");
    }


    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void Hard2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map2_hard");
    }

}
