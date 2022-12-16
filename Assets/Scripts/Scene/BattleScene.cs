using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    void Start()
    {
        var monster = BattleManager.GetInstance().GetRandomMonster();
        UIManager uimanager = UIManager.GetInstance();
        uimanager.SetEventSystem();
        uimanager.OpenUI("UIProfile");

        GameObject go = ObjectManager.GetInstance().CreateMonster(monster.monsterName);
        go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        go.transform.localPosition = new Vector3(0, 0.6f, 0);


        BattleManager.GetInstance().BattleStart(monster);
    }
}