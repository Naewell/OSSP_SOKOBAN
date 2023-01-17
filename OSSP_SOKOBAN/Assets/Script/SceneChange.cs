using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int stageNum;
    public GameObject stageNumObject;

    // Levels 씬을 불러오는 함수
    public void call() {
        SceneManager.LoadScene("Levels");
        GameManager.GetInstance().setStageNum(stageNum);
        DontDestroyOnLoad(stageNumObject);
    }

    // 만약 1번째 씬이라면 삭제
    void Update()
    {
       if(SceneManager.GetActiveScene().buildIndex == 1) Destroy(gameObject);
    }
}
