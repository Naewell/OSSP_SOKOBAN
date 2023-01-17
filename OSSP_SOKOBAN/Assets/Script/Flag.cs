
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject flag;

    // 다른 오브젝트가 통과 했을 때 함수 실행
    private void OnTriggerEnter(Collider other)
    {   
        // 태그를 비교해서 Player 이면 안보이게 감춤
        if (other.transform.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }

        // 스노우이면 스노우를 안보이게 하기
        else if(other.transform.gameObject.CompareTag("Snow"))
        {
            other.transform.gameObject.GetComponent<Renderer>().enabled = false;

        }
    }


    // 다른 오브젝트가 나갈때 비교해서 보이게하기
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (other.transform.gameObject.CompareTag("Snow"))
        {
            other.transform.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}