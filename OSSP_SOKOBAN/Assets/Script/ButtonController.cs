using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public SceneChange sc;
    private string[] numStr;
    // Start is called before the first frame update
    void Start()
    {
        numStr = new string[16];
        numStr[0] = "0";
        for (int i = 1; i < 16; i++)
        {
            numStr[i] = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBox()
    {
        string nowbutton = EventSystem.current.currentSelectedGameObject.name;
        for (int i = 1; i < numStr.Length; i++)
        {
            if (nowbutton.Equals(numStr[i]))
            {
                sc.stageNum = i;
            }
        }
        if (sc.stageNum != 0){
            sc.call();
        }
        GameManager.GetInstance().setCnt(0);
    }
}
