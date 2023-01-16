using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public SceneChange sc;
    private string[] numStr;
    private int n;
    private GameObject[] Stages;
    void Start()
    {
        numStr = new string[16];
        numStr[0] = "0";
        for (int i = 1; i < 16; i++)
        {
            numStr[i] = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBox()
    {
        string nowbutton = EventSystem.current.currentSelectedGameObject.name;
        for (int i = 1; i < numStr.Length; i++)
        {
            if (nowbutton.Equals(numStr[i]))
            {
                sc.stageNum = i;
            }
        }
        if (sc.stageNum != 0){
            sc.call();
        }
        GameManager.GetInstance().setCnt(0);
    }

    public void OnClickExitBtn()
    {
        GameManager.GetInstance().setCnt(0);
        GameManager.GetInstance().setCntFlag(0);
        SceneManager.LoadScene("StageSelect");
    }
    public void OnClickNextBtn()
    {
        GameManager.GetInstance().setCnt(0);
        GameManager.GetInstance().setCntFlag(0);
        Stages = GameManager.GetInstance().getStage();
        GameManager.GetInstance().setStageNum(GameManager.GetInstance().getStageNum()+1);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().setStepCount(0);
        GameObject.Find("Canvas").transform.Find("Clear Window").gameObject.SetActive(false);

        n = GameManager.GetInstance().getStageNum()-1;
        for (int i = 0; i < Stages.Length; i++) { Stages[i].SetActive(false); }
        Stages[n].SetActive(true);
        GameObject.Find("Main Camera").transform.position = GameObject.Find("CamPos").transform.position;
        

    }
    
    public void OnClickOptionBtn()
    {
        GameObject.Find("Canvas").transform.Find("Option Window").gameObject.SetActive(true);
    }
    public void OnClickYesBtn()
    {
        GameManager.GetInstance().setCnt(0);
        GameManager.GetInstance().setCntFlag(0);
        SceneManager.LoadScene("StageSelect");
    }
    public void OnClickNoBtn()
    {
        GameObject.Find("Option Window").gameObject.SetActive(false);
    }
}
