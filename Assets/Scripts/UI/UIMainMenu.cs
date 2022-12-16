using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public Button[] btnStart;

    void Start()
    {
        btnStart = GetComponentsInChildren<Button>();

        btnStart[0].onClick.AddListener(OnClickStart1);
        btnStart[1].onClick.AddListener(OnClickStart2);
    }

    void OnClickStart1()
    {
        GameManager.GetInstance().characterIdx = 0;
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

    void OnClickStart2()
    {
        GameManager.GetInstance().characterIdx = 1;
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}