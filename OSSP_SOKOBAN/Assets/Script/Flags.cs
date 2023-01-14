using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flags : MonoBehaviour
{
    public Material[] mat = new Material[2];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }

        if(other.transform.gameObject.CompareTag("Snow"))
        {
            gameObject.GetComponent<SkinnedMeshRenderer>().material = mat[1];
            GameManager.GetInstance().AddCnt(1);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
        }

        if(other.transform.gameObject.CompareTag("Snow"))
        {
            gameObject.GetComponent<SkinnedMeshRenderer>().material = mat[0];
            GameManager.GetInstance().SubCnt(1);
        }
    }
}
