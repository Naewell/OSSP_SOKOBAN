
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject flag;
    ParticleSystem ps;


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
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else if(other.transform.gameObject.CompareTag("Snow"))
        {
            other.transform.gameObject.GetComponent<Renderer>().enabled = false;
            //GameManager.GetInstance().AddCnt(1);
           // GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (other.transform.gameObject.CompareTag("Snow"))
        {
            other.transform.gameObject.GetComponent<Renderer>().enabled = true;
          //  GetComponent<ParticleSystem>().Stop();
            //GameManager.GetInstance().SubCnt(1);
        }
    }
}