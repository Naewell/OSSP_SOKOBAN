using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Data boolean 값 100개 배열을 만듬
    public class GameData {
    public bool[] checkTrue = new bool[100];

    // 클리어 안했을 때는 False이기 때문에 전부다 False로 초기화 해두고 첫번째 스테이지만 true로 저장
    public GameData() {
        for(int i=0; i<checkTrue.Length; i++) {
            checkTrue[i] = false;
        }
        checkTrue[0] = true;
    }
}
    private GameData gamedata;

    // 싱글톤 패턴
    public static DataManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<DataManager>();
        }

        return instance;
    }

    private static DataManager instance;

    // 파일 경로 설명 [윈도우]
    // Application.persistentDataPath : 사용자디렉토리/AppData/LocalLow/회사이름/프로덕트이름

    // 직렬화한 gamedate를 File에 저장
    public void _save() {
        string jdata = JsonConvert.SerializeObject(gamedata);
        File.WriteAllText(Application.persistentDataPath + "/database.json", jdata);
    }

    // 지정된 경로에 있는 데이터 파일을 불러옴
    public void _load() {
        if(!File.Exists(Application.persistentDataPath + "/database.json")) {
            gamedata = new GameData();
            _save();
        }
        string jdata = File.ReadAllText(Application.persistentDataPath + "/database.json");
        gamedata = JsonConvert.DeserializeObject<GameData>(jdata);

    }

    // 클리어시 게임데이터의 배열에있는 스테이지를 true로 변경
    public void setIsClear(int stagenum) {
        gamedata.checkTrue[stagenum] = true;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
         _load();
    }
}
