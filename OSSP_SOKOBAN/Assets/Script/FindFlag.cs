using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFlag : MonoBehaviour
{
    public GameObject[] countFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countFlag = GameObject.FindGameObjectsWithTag("Flag");
        GameManager.GetInstance().StageFlag(countFlag.Length);
    }
}
