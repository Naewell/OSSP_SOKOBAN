
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
    private GameObject[] Stages;
    private GameObject sceneChange;
    private int n, nowStage;
    private GameObject[] buttons = new GameObject[15];
    
    
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
   
   public void AddCnt(int newCnt) { cnt += newCnt; }
   public void SubCnt(int newCnt) { cnt -= newCnt; }
   public void setStageNum(int num) { this.num = num; }
   public void setCnt(int cnt){this.cnt = cnt; Debug.Log(this.cnt);}
   public int getStageNum() { return num; }
   public void StageFlag(int newFlag) { cntFlag = newFlag; }
   public void setCntFlag(int cntFlag){this.cntFlag = cntFlag;}
   public void AddStage(GameObject[] stage)
    {
        Stages = stage;
    }
   public GameObject[] getStage() { return Stages; }
    public void setButtons() {
        for(int i=0; i<15; i++) {
            buttons[i] = GameObject.Find((i+1).ToString());
        }
    }
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

     void Start()
    {
        isGameClear = false;
    }

    void Update()
    {
        sceneChange = GameObject.Find("StageNum");
        if (sceneChange == null)
        {
            n = 0;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && sceneChange != null)
        {
            nowStage = GameManager.GetInstance().getStageNum();//sceneChange.GetComponent<SceneChange>().stageNum;
            n = nowStage - 1;
            for (int i = 0; i < Stages.Length; i++) { Stages[i].SetActive(false); }
            setCnt(0);
            Stages[n].SetActive(true);
            GameObject.Find("Main Camera").transform.position = GameObject.Find("CamPos").transform.position;
        }

        if (SceneManager.GetActiveScene().buildIndex == 0) {
            setButtons();
            
            for(int i=0; i<buttons.Length; i++) {
                buttons[i].GetComponent<Button>().enabled = DataManager.GetInstance().getIsClear(i);
                if(DataManager.GetInstance().getIsClear(i))
                {   
                    buttons[i].GetComponent<Image>().color = Color.grey;
                }
            }
        }
    }
    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && cntFlag == cnt)
        {
            isGameClear = true;
            DataManager.GetInstance().setIsClear(getStageNum());   //n+1);
            DataManager.GetInstance()._save();
            Debug.Log("게임종료");
        }
        else isGameClear = false;

        if (SceneManager.GetActiveScene().buildIndex == 1 && isGameClear)
        {   
            GameObject.Find("Canvas").transform.Find("Clear Window").gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1 && isGameClear == false)
        {
            GameObject.Find("Canvas").transform.Find("Clear Window").gameObject.SetActive(false);
        }
    }
}
