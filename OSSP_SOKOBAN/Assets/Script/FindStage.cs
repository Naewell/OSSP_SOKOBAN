using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindStage : MonoBehaviour
{
    private GameObject[] stage;
    // Start is called before the first frame update

    // 스테이지에 현제 스케이지 저장
    void Start()
    {
        stage = new GameObject[transform.childCount];

       for(int i = 0 ; i < transform.childCount ; i++)
       {
           stage[i] = transform.GetChild(i).gameObject;
       }

       GameManager.GetInstance().AddStage(stage);
    }
}
