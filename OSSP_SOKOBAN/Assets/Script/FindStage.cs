using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindStage : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] stage;
    // Start is called before the first frame update
    void Start()
    {
        stage = new GameObject[transform.childCount];

       for(int i = 0 ; i < transform.childCount ; i++)
       {
           stage[i] = transform.GetChild(i).gameObject;
       }

       GameManager.GetInstance().AddStage(stage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
