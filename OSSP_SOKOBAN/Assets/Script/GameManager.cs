
// using System.Net.Mime;
// //using System.Diagnostics;
// using System;
// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class GameManager : MonoBehaviour
// {
//     public static GameManager GetInstance()
//     {
//         if (instance == null)
//         {
//             instance = FindObjectOfType<GameManager>();
//         }

//         return instance;
//     }
//     private bool isGameClear;
//     private static GameManager instance;
//     public int cnt = 0;
//     private int n;
//     private int cntFlag = 0;
//     private float music, sfx;
//     private GameObject[] Stages;
//     private int nowStage;
//     private GameObject sceneChange;
//     private int currentScene;
//     private int num;
//     private Sprite[] clearBtn;
//     private Sprite[] basicStarBtn;
//     private Material[] skyboxList;
//     int Random_Num;
//     private Text step_Count;

//     public void AddStage(GameObject[] stage)
//     {
//         Stages = stage;
//     }
//     public void AddCnt(int newCnt) { cnt += newCnt; }
//     public void SubCnt(int newCnt) { cnt -= newCnt; }
//     public void StageFlag(int newFlag) { cntFlag = newFlag; }
//     public GameObject[] getStage() { return Stages; }
//     public bool getIsGameClear() { return isGameClear; }
//     public void setVolume(float music, float sfx)
//     {
//         this.music = music;
//         this.sfx = sfx;
//     }

//     public void setStageNum(int num) { this.num = num; }
//     public int getStageNum() { return num; }
//     public void setCnt(int cnt){this.cnt = cnt; Debug.Log(this.cnt);}
//     public void setCntFlag(int cntFlag){this.cntFlag = cntFlag;}

//     //
//     private GameObject[] buttons = new GameObject[100];
//     public void setButtons() {
//         for(int i=0; i<100; i++) {
//             buttons[i] = GameObject.Find((i+1).ToString());
//         }
//     }

//     //

//     void Awake()
//     {
//         DontDestroyOnLoad(gameObject);

//         if (GameManager.GetInstance() == null)
//         {
//             instance = this;
//         }
//         else if (GameManager.GetInstance() != this)
//         {
//             Destroy(gameObject);
//         }
//     }
//     void Start()
//     {

//         //
        
//         //
//         isGameClear = false;
//         currentScene = SceneManager.GetActiveScene().buildIndex;

//         music = DataManager.GetInstance().getMusicVolume();
//         sfx = DataManager.GetInstance().getSfxVolume();

//         skyboxList = new Material[5];
//         skyboxList = Resources.LoadAll<Material>("Skybox/");
//         clearBtn = Resources.LoadAll<Sprite>("Btn/");
//         basicStarBtn = Resources.LoadAll<Sprite>("Basic_Select/");
//         Random_Num = UnityEngine.Random.Range(0, 5);
//     }
//     void Update()
//     { 
//         sceneChange = GameObject.Find("Stagenum");
//         if (sceneChange == null)
//         {
//             n = 0;
//         }

//         // 현재 씬이 Stage일 경우
//         if (SceneManager.GetActiveScene().buildIndex == 3) {
//             setButtons();
            
//             for(int i=0; i<buttons.Length; i++) {
//                 buttons[i].GetComponent<Button>().enabled = DataManager.GetInstance().getIsClear(i);
//                 if(DataManager.GetInstance().getIsClear(i) && buttons[i].transform.GetComponent<Image>().sprite.name.Equals("Lock", StringComparison.Ordinal))
//                 {   
//                     Random_Num = UnityEngine.Random.Range(0, 5);
//                     buttons[i].GetComponent<Image>().sprite = clearBtn[Random_Num];
//                     buttons[i].transform.GetChild(0).gameObject.SetActive(true);
//                     buttons[i].transform.GetChild(1).gameObject.SetActive(true);
//                 }
//                  if(DataManager.GetInstance().getIsClear(i))
//                 {
//                     int basicStar = DataManager.GetInstance().getBasicStar(i);                   
//                     switch(basicStar)
//                     {
//                         case 1:
//                             buttons[i].transform.GetChild(1).GetComponent<Image>().sprite = basicStarBtn[0];
//                             break;
//                         case 2 :
//                             buttons[i].transform.GetChild(1).GetComponent<Image>().sprite = basicStarBtn[1];
//                             break;
//                         case 3 :
//                             buttons[i].transform.GetChild(1).GetComponent<Image>().sprite = basicStarBtn[2];
//                             break;
//                     }
//                 }
//             }
//         }
        
//         // 현재 씬이 basic이고, 씬이 바뀐 경우
//         if (SceneManager.GetActiveScene().buildIndex == 4 && sceneChange != null)
//         {
//             nowStage = GameManager.GetInstance().getStageNum();//sceneChange.GetComponent<SceneChange>().stageNum;
//             n = nowStage - 1;
//             // skybox 전환
//             RenderSettings.skybox = skyboxList[nowStage / 21];
//             Debug.Log("GameManager - n :" + n);
//             for (int i = 0; i < Stages.Length; i++) { Stages[i].SetActive(false); }
//             setCnt(0);
//             if(nowStage > 0 || nowStage <41){
//                 GameObject.Find("Canvas").transform.Find("IceBoxCountUI").gameObject.SetActive(true);
//                 GameObject.Find("Canvas").transform.Find("BackPackCountUI").gameObject.SetActive(false);
//                 GameObject.Find("Canvas").transform.Find("SuitCaseCountUI").gameObject.SetActive(false);
//             }
//             else if ( nowStage > 40 || nowStage <71){
//                 GameObject.Find("Canvas").transform.Find("IceBoxCountUI").gameObject.SetActive(false);
//                 GameObject.Find("Canvas").transform.Find("BackPackCountUI").gameObject.SetActive(true);
//                 GameObject.Find("Canvas").transform.Find("SuitCaseCountUI").gameObject.SetActive(false);
//             }
//             else{
//                 GameObject.Find("Canvas").transform.Find("IceBoxCountUI").gameObject.SetActive(false);
//                 GameObject.Find("Canvas").transform.Find("BackPackCountUI").gameObject.SetActive(false);
//                 GameObject.Find("Canvas").transform.Find("SuitCaseCountUI").gameObject.SetActive(true);
//             }
//             Stages[n].SetActive(true);
//             GameObject.Find("Main Camera").transform.position = GameObject.Find("CamPos").transform.position;
//         }
//         //씬이 바뀐 경우
//         if (SceneManager.GetActiveScene().buildIndex != currentScene)
//         {
//             GameObject.Find("Sound Manager").GetComponent<SoundManager>().setCurrentMusicVolume(music);
//             GameObject.Find("Sound Manager").GetComponent<SoundManager>().setCurrentSfxVolume(sfx);
//             GameObject ms = GameObject.Find("Canvas").transform.Find("Option Window").transform.Find("Setting").transform.Find("Music Slider").gameObject;
//             GameObject ss = GameObject.Find("Canvas").transform.Find("Option Window").transform.Find("Setting").transform.Find("Sound Slider").gameObject;

//             ms.GetComponent<Slider>().value = music;
//             ss.GetComponent<Slider>().value = sfx;

//             currentScene = SceneManager.GetActiveScene().buildIndex;
//         }

//         if(SceneManager.GetActiveScene().buildIndex == 4)
//         {
//             GameObject.Find("Canvas").transform.Find("IceBoxCountUI").transform.Find("Count").GetComponent<Text>().text = cnt + " / " + cntFlag;
//             GameObject.Find("Canvas").transform.Find("BackPackCountUI").transform.Find("Count").GetComponent<Text>().text = cnt + " / " + cntFlag;
//             GameObject.Find("Canvas").transform.Find("SuitCaseCountUI").transform.Find("Count").GetComponent<Text>().text = cnt + " / " + cntFlag;
//         }

//     }

//     void LateUpdate()
//     {
//         if (SceneManager.GetActiveScene().buildIndex == 4 && cntFlag == cnt)
//         {
//             isGameClear = true;
//             //
//             DataManager.GetInstance().setIsClear(getStageNum());   //n+1);
//             int tmpstep = GameObject.Find("player").GetComponent<PlayerController>().getStepCount();
//             Debug.Log("tmpstep : " + tmpstep);
//             DataManager.GetInstance().setStep(getStageNum(), tmpstep);
//             Debug.Log("getStagenum : " + getStageNum());
//             GameObject.Find("Button Controller").GetComponent<ButtonController>().setResetPositionList();
//             DataManager.GetInstance()._save();
//             DataManager.GetInstance()._saveBasicScore();
//             //
//             Debug.Log("게임종료");
//         }
//         else isGameClear = false;

//         if (SceneManager.GetActiveScene().buildIndex == 4 && isGameClear)
//         {   
//             int[] basicStep = new int[2];
//             basicStep[0] = DataManager.GetInstance().getBasicStepList(getStageNum())[0];
//             basicStep[1] = DataManager.GetInstance().getBasicStepList(getStageNum())[1];
//             Debug.Log(basicStep[0]);
//             Debug.Log(basicStep[1]);
//             int step = GameObject.Find("player").GetComponent<PlayerController>().getStepCount(); 
//             //DataManager.GetInstance().getBaiscStep(getStageNum()-1);
//             Debug.Log(step);

//             // if(getStageNum() > 0 && getStageNum() < 10)
//             // {
//             //     //GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Single_Letter").transform.Find("Stage_Num").GetComponent<TMpro.TextMeshProUGUI>().text = nowStage.ToString();
//             //     GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Single_Letter").gameObject.SetActive(true);
//             // }

//             if(step > basicStep[0]){
//                 GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Clear_Light").gameObject.SetActive(true);
//                 GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Clear").gameObject.SetActive(true);
//             }
//             else if (step > basicStep[1]){
//                 GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Clear_Light").gameObject.SetActive(true);
//                 GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Great_Light").gameObject.SetActive(true);
//                 GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Great").gameObject.SetActive(true);
//             }
//             else if (step <= basicStep[1]){
//                 GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Clear_Light").gameObject.SetActive(true);
//                 GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Great_Light").gameObject.SetActive(true);
//                 GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Perfect_Light").gameObject.SetActive(true);
//                 GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Perfect").gameObject.SetActive(true);    
//             }
//             step_Count = GameObject.Find("Canvas").transform.Find("Clear Window").transform.Find("Image").transform.Find("Step_Count").GetComponent<Text>();
//             GameObject.Find("Canvas").transform.Find("Clear Window").gameObject.SetActive(true);
//         //    .text = GameObject.Find("player").GetComponent<PlayerController>().getStepCount().ToString();
//            step_Count.text = GameObject.Find("Button Controller").GetComponent<ButtonController>().getStepCount().ToString();
//         }
//         else if (SceneManager.GetActiveScene().buildIndex == 4 && isGameClear == false)
//         {
//             GameObject.Find("Canvas").transform.Find("Clear Window").gameObject.SetActive(false);
//         }
//     }
// }
