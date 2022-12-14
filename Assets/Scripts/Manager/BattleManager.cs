using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private ObjectPool objectPool;

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

    public Monster1 monsterData;

    GameObject uiTab;

    private void Awake()
    {
        objectPool = new ObjectPool();
    }

    public void BattleStart(Monster1 monster)
    {
        monsterData = monster;

        EffectManager.GetInstance().InitEffectPool(2);

        UIManager.GetInstance().OpenUI("UITab");

        StartCoroutine("BattleProgress");
    }

    IEnumerator BattleProgress()
    {
        while (GameManager.GetInstance().curhp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            GameManager.GetInstance().SetCurrentHP(-damage);

            GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
            if (ui != null)
            {
                ui.GetComponent<UIProfile>().RefreshState();
            }

            Debug.Log($"몬스터가 플레이어에게 공격을 했습니다. | 대미지: -{damage} | 남은 체력: {GameManager.GetInstance().curhp}");
        }

        Lose();
    }

    public void AttackMonster()
    {
        EffectManager.GetInstance().UseEffect();

        monsterData.hp--;

        if (monsterData.hp <= 0)
        {
            objectPool.DestroyObjects();
            Victory();
        }
    }

    public void Hit()
    {
        float randX = Random.Range(-0.7f, 0.7f);
        float randY = Random.Range(-0.7f, 0.7f);

        ParticleSystem particle = ObjectManager.GetInstance().CreateHitEffect();
        particle.transform.localScale = new Vector3(0.2f, 0.2f, 0.3f);
        particle.transform.localPosition = new Vector3(0 + randX, 0.7f + randY, -0.5f);
    }

    void Victory()
    {
        Debug.Log("게임에서 승리했습니다.");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterData.gold);


        Invoke("MoveToMain", 2.5f);
    }

    void Lose() 
    {
        Debug.Log ("게임에서 패배했습니다.");
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
