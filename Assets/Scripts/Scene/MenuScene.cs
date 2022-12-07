using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    void Start()
    {
        UIManager manager = UIManager.GetInstance();
        manager.SetEventSystem();
        manager.OpenUI("UIMainMenu");
    }
}