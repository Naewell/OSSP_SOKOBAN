using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int stageNum;
    public GameObject stageNumObject;

    public void Start()
    {
    }

    public void call() {
        SceneManager.LoadScene("Levels");
        GameManager.GetInstance().setStageNum(stageNum);
        DontDestroyOnLoad(stageNumObject);
    }

    void Update()
    {
       if(SceneManager.GetActiveScene().buildIndex == 1) Destroy(gameObject);
    }
}
