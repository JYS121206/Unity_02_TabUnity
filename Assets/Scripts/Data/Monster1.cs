using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Monster1
{
    public string monsterName;

    public int atk;
    public int hp;
    public int exp;

    public float delay;

    public int gold;

    public Monster1(string monsterName, int atk, int hp, int exp, float delay, int gold)
    {
        this.monsterName = monsterName;
        this.atk = atk;
        this.hp = hp;
        this.exp = exp;
        this.delay = delay;
        this.gold = gold;
    }   
}