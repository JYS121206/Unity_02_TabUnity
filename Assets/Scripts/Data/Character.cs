using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string playerName;
    public string playerImg;

    public int totalExp;
    public int curExp;

    public int level;

    public int gold;

    public int totalhp;
    public int curhp;

    public Character(string playerName, string playerImg, int totalExp, int curExp,  int level, int gold, int totalhp, int curhp)
    {
        this.playerName = playerName;
        this.playerImg = playerImg;
        this.totalExp = totalExp;
        this.curExp = curExp;
        this.level = level;
        this.gold = gold;
        this.totalhp = totalhp;
        this.curhp = curhp;
    }
}
