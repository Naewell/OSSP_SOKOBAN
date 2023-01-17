using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFlag : MonoBehaviour
{
    public GameObject[] countFlag;

    // 시작할 때 Flag 개수 카운트
    void Update()
    {
        countFlag = GameObject.FindGameObjectsWithTag("Flag");
        GameManager.GetInstance().StageFlag(countFlag.Length);
    }
}
