using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionMenu : MonoBehaviour
{
    public Button btnPractice;
    public Button btnHealing;
    public Button btnBattle;
    public Button characterAnim;
    public Button btnMenu;

    private void Start()
    {

        GameObject ui = UIManager.GetInstance().GetUI("UIProfile");

        btnBattle.onClick.AddListener(OnClickBattle);
        btnHealing.onClick.AddListener(OnClickHeal);
        btnMenu.onClick.AddListener(OnClickMenu);
        characterAnim.onClick.AddListener(MainScene.PlayAnimation);
    }

    void OnClickBattle()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Battle);
    }

    void OnClickHeal()
    {
        if (GameManager.GetInstance().SpendGold(300))
            GameManager.GetInstance().SetCurrentHP(50);
        GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
        if (ui != null)
        {
            ui.GetComponent<UIProfile>().RefreshState();
        }
    }

    void OnClickMenu()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Menu);
    }
}