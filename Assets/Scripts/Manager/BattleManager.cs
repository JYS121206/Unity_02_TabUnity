using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone
    private static BattleManager instance = null;

    public static BattleManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@BattleManager");
            instance = go.AddComponent<BattleManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public Monster1[] monsterDatas = new Monster1[]
        {
            new Monster1("Monster1", 10, 10, 30, 2.5f, 300),
            new Monster1("Monster2", 15, 15, 70, 2f, 1000)
        };

    public Monster1 GetRandomMonster()
    {
        int rand = Random.Range(0,monsterDatas.Length);

        return monsterDatas[rand];
    }

    public Monster1 monsterData;

    GameObject uiTab;

    public void BattleStart(Monster1 monster)
    {
        monsterData = monster;

        EffectManager.GetInstance().InitEffectPool(2);

        UIManager.GetInstance().OpenUI("UITab");

        StartCoroutine("BattleProgress");
    }

    IEnumerator BattleProgress()
    {
        var character = GameManager.GetInstance().GetCharacterIdx();

        while (character.curhp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            GameManager.GetInstance().SetCurrentHP(-damage);

            GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
            if (ui != null)
            {
                ui.GetComponent<UIProfile>().RefreshState();
            }

            Debug.Log($"���Ͱ� �÷��̾�� ������ �߽��ϴ�. | �����: -{damage} | ���� ü��: {character.curhp}");
        }

        Lose();
    }

    public void AttackMonster()
    {
        EffectManager.GetInstance().UseEffect();

        monsterData.hp--;
        if (monsterData.hp <= 0)
        {
            Victory();
        }
    }

    void Victory()
    {
        Debug.Log("���ӿ��� �¸��߽��ϴ�.");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterData.gold);
        GameManager.GetInstance().AddExp(monsterData.exp);

        Invoke("MoveToMain", 2.5f);
    }

    void Lose() 
    {
        Debug.Log ("���ӿ��� �й��߽��ϴ�.");
        UIManager.GetInstance().CloseUI("UITab");

        if (GameManager.GetInstance().SpendGold(500))
        GameManager.GetInstance().SetCurrentHP(80);
        else
            GameManager.GetInstance().SetCurrentHP(10);

        Invoke("MoveToMain", 2.5f);
    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
