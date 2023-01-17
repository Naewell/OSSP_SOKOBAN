
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DetectObject : MonoBehaviour
{
    // LayerMask 이용
    public LayerMask wall;

    // Ray 변수
    private float rayDistance = 5f;
    public bool cangoW, cangoA, cangoS, cangoD;
    RaycastHit hitW, hitA, hitS, hitD;
    bool ishitW, ishitA, ishitS, ishitD;
    public GameObject objW, objA, objS, objD;

    // Update is called once per frame
    void Update()
    {
        // 레이의 원점
        Vector3 rayOrigin = this.gameObject.transform.position + new Vector3(0, 0, 0);

        // 레이의 각 방향 저장
        Vector3 rayDirw = Vector3.forward;
        Vector3 rayDira = Vector3.left;
        Vector3 rayDirs = Vector3.back;
        Vector3 rayDird = Vector3.right;

        // 레이 발사
        Ray rayw = new Ray(rayOrigin, rayDirw);
        Ray raya = new Ray(rayOrigin, rayDira);
        Ray rays = new Ray(rayOrigin, rayDirs);
        Ray rayd = new Ray(rayOrigin, rayDird);

        // 식별할 수 있게 각 광선마다 색깔 지정
        Debug.DrawRay(rayw.origin, rayw.direction * rayDistance, Color.green);
        Debug.DrawRay(raya.origin, raya.direction * rayDistance, Color.red);
        Debug.DrawRay(rays.origin, rays.direction * rayDistance, Color.yellow);
        Debug.DrawRay(rayd.origin, rayd.direction * rayDistance, Color.blue);

        // 각 광선 방향에 닿은 오브젝트를 감지해서 변수에 저장
        ishitW = Physics.Raycast(rayw, out hitW, rayDistance);
        ishitA = Physics.Raycast(raya, out hitA, rayDistance);
        ishitS = Physics.Raycast(rays, out hitS, rayDistance);
        ishitD = Physics.Raycast(rayd, out hitD, rayDistance);

        //앞에 아무것도 없거나 깃발이면 이동 가능하고 레이에 맞은 obj 없음
        if(ishitW == false || (ishitW == true && hitW.transform.gameObject.CompareTag("Flag"))) {
            cangoW = true;   
            objW = null;
        }
        //앞에 오브젝트가 있지만 벽이 아니면, 이동 가능하고 레이에 맞은 obj 저장
        else if(ishitW == true && !(hitW.transform.gameObject.CompareTag("Wall"))) {
            cangoW = true;
            objW = hitW.collider.gameObject; 
        }
        //앞에 벽이 있으면 이동 불가능하고 레이에 맞은 obj 초기화
        else {
            cangoW = false;
            objW = null;
        }

        // 각 방향 갈 수 있는지 체크
        if(ishitA == false || (ishitA == true && hitA.transform.gameObject.CompareTag("Flag"))) {
            cangoA = true;   
            objA = null;
        }
        else if(ishitA == true && !(hitA.transform.gameObject.CompareTag("Wall"))) {
            cangoA = true;
            objA = hitA.collider.gameObject;
        }
        else {
            cangoA = false;
            objA = null;
        }

        if(ishitS == false || (ishitS == true && hitS.transform.gameObject.CompareTag("Flag"))) {
            cangoS = true;   
            objS = null;
        }
        else if(ishitS == true && !(hitS.transform.gameObject.CompareTag("Wall"))) {
            cangoS = true;
            objS = hitS.collider.gameObject;
        }
        else {
            cangoS = false;
            objS = null;
        }

        if(ishitD == false || (ishitD == true && hitD.transform.gameObject.CompareTag("Flag"))) {
            cangoD = true;   
            objD = null;
        }
        else if(ishitD == true && !(hitD.transform.gameObject.CompareTag("Wall"))) {
            cangoD = true;
            objD = hitD.collider.gameObject;
        }
        else {
            cangoD = false;
            objD = null;
        }
    }
}