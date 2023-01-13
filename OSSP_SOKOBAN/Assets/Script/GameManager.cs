
using System.Net.Mime;
//using System.Diagnostics;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int cnt = 0;
    private bool isGameClear;
    private int cntFlag = 0;
    
    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();
        }

        return instance;
    }
   private static GameManager instance;
   private int num;

   public void setStageNum(int num) { this.num = num; }
   public void setCnt(int cnt){this.cnt = cnt; Debug.Log(this.cnt);}
    public int getStageNum() { return num; }
   void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (GameManager.GetInstance() == null)
        {
            instance = this;
        }
        else if (GameManager.GetInstance() != this)
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && cntFlag == cnt)
        {
            isGameClear = true;
            DataManager.GetInstance().setIsClear(getStageNum());   //n+1);
            int tmpstep = GameObject.Find("player").GetComponent<PlayerController>().getStepCount();
        }
        else isGameClear = false;

        if (SceneManager.GetActiveScene().buildIndex == 4 && isGameClear)
        {   
            int step = GameObject.Find("player").GetComponent<PlayerController>().getStepCount();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4 && isGameClear == false)
        {
            GameObject.Find("Canvas").transform.Find("Clear Window").gameObject.SetActive(false);
        }
    }
}
