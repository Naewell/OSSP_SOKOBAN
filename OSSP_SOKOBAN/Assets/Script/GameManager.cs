
using System.Net.Mime;
//using System.Diagnostics;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
}
