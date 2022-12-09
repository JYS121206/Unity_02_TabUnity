using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singletone
    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public string playerName = "Perioe";

    public int level = 99;

    public int gold = 1000;

    public int totalhp = 100;
    public int curhp = 100;

    public void AddGold(int gold)
    {
        this.gold += gold;
    }

    public bool SpendGold(int gold)
    {
        if (this.gold >= gold)
        {
            this.gold -= gold;
            return true;
        }
        else
            return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalhp += addHp;
    }

    public void SetCurrentHP(int hp)
    {
        curhp += hp;

        if (curhp > totalhp)
            curhp = totalhp;

        if (curhp < 0)
            curhp = 0;

        //Mathf.Clamp(curhp, 0, totalhp);
    }

}