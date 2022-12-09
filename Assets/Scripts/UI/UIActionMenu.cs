using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionMenu : MonoBehaviour
{
    public Button btnPractice;
    public Button btnHealing;
    public Button btnBattle;

    private void Start()
    {
        GameObject ui = UIManager.GetInstance().GetUI("UIProfile");


        btnBattle.onClick.AddListener(OnClickBattle);
    }

    void OnClickBattle()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Battle);
    }
}