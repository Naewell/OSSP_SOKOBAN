using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
public class SnowDetect : MonoBehaviour
{
    RaycastHit hitW, hitA, hitS, hitD;
    private float rayDistance = 5f;
    public GameObject objW, objA, objS, objD;
    public bool cangoW, cangoA, cangoS, cangoD;
    bool ishitW, ishitA, ishitS, ishitD;
    private string myName, otherName;
    private int myNum, otherNum;
    public bool isSameNum, _have;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = this.gameObject.transform.position;

        Vector3 rayDirw = Vector3.forward;
        Vector3 rayDira = Vector3.left;
        Vector3 rayDirs = Vector3.back;
        Vector3 rayDird = Vector3.right;

        Ray rayw = new Ray(rayOrigin, rayDirw);
        Ray raya = new Ray(rayOrigin, rayDira);
        Ray rays = new Ray(rayOrigin, rayDirs);
        Ray rayd = new Ray(rayOrigin, rayDird);

        Debug.DrawRay(rayw.origin, rayw.direction * rayDistance, Color.green);
        Debug.DrawRay(raya.origin, raya.direction * rayDistance, Color.red);
        Debug.DrawRay(rays.origin, rays.direction * rayDistance, Color.yellow);
        Debug.DrawRay(rayd.origin, rayd.direction * rayDistance, Color.blue);

        ishitW = Physics.Raycast(rayw, out hitW, rayDistance);
        ishitA = Physics.Raycast(raya, out hitA, rayDistance);
        ishitS = Physics.Raycast(rays, out hitS, rayDistance);
        ishitD = Physics.Raycast(rayd, out hitD, rayDistance);

        //앞에 아무것도 없거나 깃발이면, 이동 가능하고 레이에 맞은 obj가 없음
        if(ishitW == false || (ishitW == true && hitW.transform.gameObject.CompareTag("Flag"))) {
            cangoW = true;
            objW = null;
        }
        //앞에 오브젝트가 있지만 현재 오브젝트 레이어와 앞 오브젝트 레이어 차이가 1이면, 이동 가능하고 레이에 맞은 obj 저장
        else if(ishitW == true && (Mathf.Abs(transform.gameObject.layer - hitW.transform.gameObject.layer) == 1)) {
            cangoW = true;
            objW = hitW.collider.gameObject;
            myName = gameObject.name;
            otherName = objW.gameObject.name;
            if(Regex.Replace(myName, @"[^0-9]", "")==Regex.Replace(otherName, @"[^0-9]", "")) isSameNum = true;
            else isSameNum = false;
            if(myName.Contains("_") || otherName.Contains("_")) _have = true;
            else _have = false;
        }
        //앞에 오브젝트가 있으면, 이동 불가능하고 레이에 맞은 obj 초기화
        else {
            cangoW = false;
            objW = null;
        }

        if(ishitA == false || (ishitA == true && hitA.transform.gameObject.CompareTag("Flag"))) {
            cangoA = true;
            objA = null;
        }
        else if(ishitA == true && (Mathf.Abs(transform.gameObject.layer - hitA.transform.gameObject.layer) == 1)) {
            cangoA = true;
            objA = hitA.collider.gameObject;
            myName = gameObject.name;
            otherName = objA.gameObject.name;
            if(Regex.Replace(myName, @"[^0-9]", "")==Regex.Replace(otherName, @"[^0-9]", "")) isSameNum = true;
            else isSameNum = false;
            if(myName.Contains("_") || otherName.Contains("_")) _have = true;
            else _have = false;
        }
        else {
            cangoA = false;
            objA = null;
        }

        if(ishitS == false || (ishitS == true && hitS.transform.gameObject.CompareTag("Flag"))) {
            cangoS = true;
            objS = null;
        }
        else if(ishitS == true && (Mathf.Abs(transform.gameObject.layer - hitS.transform.gameObject.layer) == 1)) {
            cangoS = true;
            objS = hitS.collider.gameObject;
            myName = gameObject.name;
            otherName = objS.gameObject.name;
            if(Regex.Replace(myName, @"[^0-9]", "")==Regex.Replace(otherName, @"[^0-9]", "")) isSameNum = true;
            else isSameNum = false;
            if(myName.Contains("_") || otherName.Contains("_")) _have = true;
            else _have = false;
        }
        else {
            cangoS = false;
            objS = null;
        }

        if(ishitD == false || (ishitD == true && hitD.transform.gameObject.CompareTag("Flag"))){
            cangoD = true;
            objD = null;
        }
        else if(ishitD == true && (Mathf.Abs(transform.gameObject.layer - hitD.transform.gameObject.layer) == 1)) {
            cangoD = true;
            objD = hitD.collider.gameObject;
            myName = gameObject.name;
            otherName = objD.gameObject.name;
            if(Regex.Replace(myName, @"[^0-9]", "")==Regex.Replace(otherName, @"[^0-9]", "")) isSameNum = true;
            else isSameNum = false;
            if(myName.Contains("_") || otherName.Contains("_")) _have = true;
            else _have = false;
        }
        else {
            cangoD = false;
            objD = null;
        }
    }
    
    // 눈이 깃발에 닿으면 안보이게
    // 눈이나 깃발에 istrigger 설정 해줘야 함
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Flag"))
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    // 닿은 부분 빠져나오면 다시 보이게
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Flag"))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}