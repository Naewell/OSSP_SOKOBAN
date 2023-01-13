using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class DataManager : MonoBehaviour
{
    public class GameData {
    public float musicVolume;
    public float sfxVolume;
    public bool[] checkTrue = new bool[100];

    public GameData() {
        for(int i=0; i<checkTrue.Length; i++) {
            checkTrue[i] = false;
        }
        checkTrue[0] = true;
    }
}
    private GameData gamedata;
    public static DataManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<DataManager>();
        }

        return instance;
    }

    private static DataManager instance;

    public void _save() {
        string jdata = JsonConvert.SerializeObject(gamedata);
        File.WriteAllText(Application.persistentDataPath + "/database.json", jdata);
    }

    public void _load() {
        if(!File.Exists(Application.persistentDataPath + "/database.json")) {
            gamedata = new GameData();
            _save();
        }
        string jdata = File.ReadAllText(Application.persistentDataPath + "/database.json");
        gamedata = JsonConvert.DeserializeObject<GameData>(jdata);

    }
    public void setIsClear(int stagenum) {
        gamedata.checkTrue[stagenum] = true;
    }
    // Start is called before the first frame update
    void Awake()
    {
         _load();
    }
}
