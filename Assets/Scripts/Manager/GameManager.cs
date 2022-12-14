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

    public int gold = 500; //추가, 삭제

    public int totalhp = 100; //증가
    public int curhp = 100; //증가, 감소

    public void LoadData()
    {
        playerName = PlayerPrefs.GetString("playerName", "Perioe");

        level = PlayerPrefs.GetInt("level", 1);
        gold = PlayerPrefs.GetInt("gold", 500);
        totalhp = PlayerPrefs.GetInt("totalhp", 100);
        curhp = PlayerPrefs.GetInt("curhp", 100);
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("playerName", playerName);

        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("totalhp", totalhp);
        PlayerPrefs.SetInt("curhp", curhp);

    }

    public void AddGold(int gold)
    {
        this.gold += gold;
        SaveData();
    }

    public bool SpendGold(int gold)
    {
        if (this.gold >= gold)
        {
            this.gold -= gold;
            SaveData();
            return true;
        }
        else
            return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalhp += addHp;
        SaveData();
    }

    public void SetCurrentHP(int hp)
    {
        curhp += hp;

        if (curhp > totalhp)
            curhp = totalhp;

        if (curhp < 0)
            curhp = 0;
        SaveData();

        //Mathf.Clamp(curhp, 0, totalhp);
    }

}