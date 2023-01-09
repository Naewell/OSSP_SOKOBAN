using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    private GameObject[] hamburger = new GameObject[4];
    string objName;

    private Vector3 velo = Vector3.zero;

    private bool isMoving = false;
    
    private Vector3 targetPosition;
    private Vector3 objTargetPosition;

    private float timer = 0;
    private int StepCount = 0;

    private GameObject firstObj;
    


    void start()
    {
        //안됨... 수정해야함
        hamburger = Resources.LoadAll<GameObject>("Hamburger/");
    }


    void Update()
    {
        if (isMoving == false) 
        {
            if (Input.GetKeyDown(KeyCode.W)) 
            {
                firstObj = null;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //플레이어 이동 가능, 플레이어 앞에 아무것도 없음
                //플레이어 이동
                if(GameObject.Find("player").GetComponent<DetectObject>().cangoW && 
                GameObject.Find("player").GetComponent<DetectObject>().objW is null) 
                {
                    isMoving = true;
                    targetPosition = transform.position + Vector3.up * 10;
                }
                
                //플레이어 이동 가능, 플레이어 앞에 무언가 있음
                //앞에 있는 오브젝트 저장
                
                else if (GameObject.Find("player").GetComponent<DetectObject>().cangoW &&
                         GameObject.Find("player").GetComponent<DetectObject>().objW != null)
                {
                    firstObj = GameObject.Find("player").GetComponent<DetectObject>().objW;

                    //플레이어 앞의 오브젝트가 이동 가능, 오브젝트 앞에 아무것도 없음
                    //플레이어 이동 및 오브젝트 이동
                    if (firstObj.GetComponent<SnowDetect>().cangoW &&
                        firstObj.GetComponent<SnowDetect>().objW is null)
                    {
                        isMoving = true;
                        targetPosition = transform.position + Vector3.forward * 10;
                        objTargetPosition = firstObj.transform.position + Vector3.forward * 10;
                    }
                }
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                firstObj = null;
                transform.rotation = Quaternion.Euler(0, 270, 0);
                if(GameObject.Find("player").GetComponent<DetectObject>().cangoA &&
                GameObject.Find("player").GetComponent<DetectObject>().objA is null) {
                    isMoving = true;
                    targetPosition = transform.position + Vector3.left * 10;
                }
                
                else if (GameObject.Find("player").GetComponent<DetectObject>().cangoA && 
                GameObject.Find("player").GetComponent<DetectObject>().objA != null)
                {
                    firstObj = GameObject.Find("player").GetComponent<DetectObject>().objA;
                    
                    if (firstObj.GetComponent<SnowDetect>().cangoA &&
                        firstObj.GetComponent<SnowDetect>().objA is null)
                    {
                        isMoving = true;
                        targetPosition = transform.position + Vector3.left * 10;
                        objTargetPosition = firstObj.transform.position + Vector3.left * 10;
                    }

                 }
             }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                firstObj = null;
                
                transform.rotation = Quaternion.Euler(0, 180, 0);

                if(GameObject.Find("player").GetComponent<DetectObject>().cangoS &&
                   GameObject.Find("player").GetComponent<DetectObject>().objS is null) {
                    isMoving = true;
                    targetPosition = transform.position + Vector3.back * 10;
                }
                
                else if (GameObject.Find("player").GetComponent<DetectObject>().cangoS &&
                         GameObject.Find("player").GetComponent<DetectObject>().objS != null)
                {
                    firstObj = GameObject.Find("player").GetComponent<DetectObject>().objS;
                    
                    if (firstObj.GetComponent<SnowDetect>().cangoS &&
                        firstObj.GetComponent<SnowDetect>().objS is null)
                    {
                        isMoving = true;
                        targetPosition = transform.position + Vector3.down * 10;
                        objTargetPosition = firstObj.transform.position + Vector3.down * 10;
                    }
                 }
             }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                firstObj = null;

                transform.rotation = Quaternion.Euler(0, 90, 0);;
                
                if(GameObject.Find("player").GetComponent<DetectObject>().cangoD &&
                   GameObject.Find("player").GetComponent<DetectObject>().objD is null) {
                    isMoving = true;
                    targetPosition = transform.position + Vector3.right * 10;
                }
                
                else if (GameObject.Find("player").GetComponent<DetectObject>().cangoD &&
                         GameObject.Find("player").GetComponent<DetectObject>().objD != null)
                {
                    firstObj = GameObject.Find("player").GetComponent<DetectObject>().objD;
                    
                    if (firstObj.GetComponent<SnowDetect>().cangoD &&
                        firstObj.GetComponent<SnowDetect>().objD is null)
                    {
                        isMoving = true;
                        targetPosition = transform.position + Vector3.right * 10;
                        objTargetPosition = firstObj.transform.position + Vector3.right * 10;
                    }

                 }
             }
        
         }  

        if (isMoving == true)
        {
            if(firstObj is null)
                aloneMoving();
            else
                togetherMoving();
        }
    }


     private void aloneMoving()
    {
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition, ref velo, 0.1f);
        //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition, 0.07f);

        aloneWaitTime();
    }

    private void togetherMoving()
    {
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition, ref velo, 0.1f);
        firstObj.transform.position = Vector3.SmoothDamp(firstObj.transform.position, objTargetPosition, ref velo, 0.1f);
        togetherWaitTime();
    }

    private void aloneWaitTime()
    {
        timer += Time.deltaTime;
        if (timer > 0.25f)
        {
            timer = 0;
            isMoving = false;
            gameObject.transform.position = targetPosition;
        }
    }
    
    private void togetherWaitTime()
    {
        timer += Time.deltaTime;
        if (timer > 0.25f)
        {
            timer = 0;
            isMoving = false;
            gameObject.transform.position = targetPosition;
            firstObj.transform.position = objTargetPosition;
        }
    }

    public void setStepCount(int count)
    {
        this.StepCount = count;
    }

    public int getStepCount()
    {
        return StepCount;
    }

    public void plusStepCount()
    {
        this.StepCount++;
    }
}
