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

    // 스테이지 버튼을 눌렀을 때 플레이 씬을 부르는 함수
    public void OnClickBox()
    {
        // 클릭한 버튼의 이름을 String으로 가져옴
        string nowbutton = EventSystem.current.currentSelectedGameObject.name;

        // numStr 배열에 있는 숫자와 같은 숫자면
        for (int i = 1; i < numStr.Length; i++)
        {
            if (nowbutton.Equals(numStr[i]))
            {
                sc.stageNum = i;
            }
        }

        // 씬을 Call
        if (sc.stageNum != 0){
            sc.call();
        }
        GameManager.GetInstance().setCnt(0);
    }

    // Exit 버튼을 눌렀을 때 스테이지 선택 화면으로 돌아가는 함수
    public void OnClickExitBtn()
    {
        // 카운트들 전부 초기화 후 씬 불러오기
        GameManager.GetInstance().setCnt(0);
        GameManager.GetInstance().setCntFlag(0);
        SceneManager.LoadScene("StageSelect");
    }

    // Next 버튼을 눌렀을 때 다음 스테이지로 넘어가는 함수
    public void OnClickNextBtn()
    {
        // 전부 초기화 한후
        GameManager.GetInstance().setCnt(0);
        GameManager.GetInstance().setCntFlag(0);

        // 다음 스테이지의 번호를 가져와서 저장한 후 클리어 창을 닫음
        Stages = GameManager.GetInstance().getStage();
        GameManager.GetInstance().setStageNum(GameManager.GetInstance().getStageNum()+1);
        GameObject.Find("Canvas").transform.Find("Clear Window").gameObject.SetActive(false);

        // 배열이기 때문에 -1을 빼서 변수를 저장한 후 그 Stage배열안에 있는 n번째 인덱스를 활성화
        n = GameManager.GetInstance().getStageNum()-1;
        for (int i = 0; i < Stages.Length; i++) { Stages[i].SetActive(false); }
        Stages[n].SetActive(true);
        GameObject.Find("Main Camera").transform.position = GameObject.Find("CamPos").transform.position;
    }
    
    // Option 버튼을 눌렀을 때 옵션 창을 뜨게 하는 함수
    public void OnClickOptionBtn()
    {
        GameObject.Find("Canvas").transform.Find("Option Window").gameObject.SetActive(true);
    }

    // Yes 버튼을 눌렀을 때 스테이지 선택 화면으로 돌아가는 함수
    public void OnClickYesBtn()
    {
        // 초기화한 후 스테이지 선택 씬 불러오기
        GameManager.GetInstance().setCnt(0);
        GameManager.GetInstance().setCntFlag(0);
        SceneManager.LoadScene("StageSelect");
    }

    // No 버튼을 눌렀을 때 창을 닫는 함수
    public void OnClickNoBtn()
    {
        // Option Window 창 닫기
        GameObject.Find("Option Window").gameObject.SetActive(false);
    }
}
