using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    void Start()
    {
        ObjectManager manager = ObjectManager.GetInstance();
        manager.CreateCharacter();

        UIManager uimanager = UIManager.GetInstance();
        uimanager.SetEventSystem();
        uimanager.OpenUI("UIProfile");
        uimanager.OpenUI("UIActionMenu");
    }
}