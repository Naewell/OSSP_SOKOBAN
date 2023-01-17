using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flags : MonoBehaviour
{
    public Material[] mat = new Material[2];

    // 다른 오브젝트와 충돌 감지해서 플레이어면 안보이게 스노우면 지정해둔 색깔로 변경 및 카운트 하나 증가
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

    // 다른 오브젝트와 충돌 감지해서 나갔으면 플레이어면 보이게하고 스노우면 지정해둔 색깔로 변경 및 카운트 하나 감소
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
