using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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

    public int characterIdx = 0;

    public Character[] characters = new Character[]
    {
        new Character("Skeletone", "Character", 100, 0, 1, 500, 120, 120),
        new Character("Mage", "Character2", 100, 0, 1, 1000, 100, 100)
    };

    /// <summary>
    /// characters[Idx]를 리턴합니다.
    /// </summary>
    /// <returns></returns>
    public Character GetCharacterIdx()
    {
        return characters[characterIdx];
    }

    public void LoadData()
    {
        Character Character = GetCharacterIdx();

        // "playerName_0"  "playerName_1"  
        // $"playerName_{idx}"  
        Character.playerName = PlayerPrefs.GetString($"playerName_{characterIdx}", Character.playerName);
        Character.playerImg = PlayerPrefs.GetString($"playerImg_{characterIdx}", Character.playerImg);

        Character.level = PlayerPrefs.GetInt($"level_{characterIdx}", Character.level);
        Character.gold = PlayerPrefs.GetInt($"gold_{characterIdx}", Character.gold);
        Character.totalhp = PlayerPrefs.GetInt($"totalhp_{characterIdx}", Character.totalhp);
        Character.curhp = PlayerPrefs.GetInt($"curhp_{characterIdx}", Character.curhp);
    }

    public void SaveData()
    {
        Character Character = GetCharacterIdx();

        PlayerPrefs.SetString($"playerName_{characterIdx}", Character.playerName);
        PlayerPrefs.SetString($"playerImg_{characterIdx}", Character.playerImg);

        PlayerPrefs.SetInt($"level_{characterIdx}", Character.level);
        PlayerPrefs.SetInt($"gold_{characterIdx}", Character.gold);
        PlayerPrefs.SetInt($"totalhp_{characterIdx}", Character.totalhp);
        PlayerPrefs.SetInt($"curhp_{characterIdx}", Character.curhp);

    }

    public void AddGold(int gold)
    {
        GetCharacterIdx().gold += gold;
        SaveData();
    }
    public void AddExp(int exp)
    {
        var character = GetCharacterIdx();

        character.curExp += exp;
        if (character.curExp >= character.totalExp)
        {
            character.level++;
            character.curExp = 0;
            character.totalExp += 10;
        }

        SaveData();
    }

    public bool SpendGold(int gold)
    {
        if (GetCharacterIdx().gold >= gold)
        {
            GetCharacterIdx().gold -= gold;
            SaveData();
            return true;
        }
        else
            return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        GetCharacterIdx().totalhp += addHp;
        SaveData();
    }

    public void SetCurrentHP(int hp)
    {
        var character = GetCharacterIdx();

        character.curhp += hp;

        if (character.curhp > character.totalhp)
            character.curhp = character.totalhp;

        if (character.curhp < 0)
            character.curhp = 0;
        SaveData();

        //Mathf.Clamp(character.curhp, 0, character.totalhp);
        //위에 있는 if문을 한줄로 축약함
    }

}