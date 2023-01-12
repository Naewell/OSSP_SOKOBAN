
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
}
