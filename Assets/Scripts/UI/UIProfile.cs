using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProfile : MonoBehaviour
{
    public Slider hpBar;
    public Image imgFill;
    public TMP_Text txtHp;

    public TMP_Text txtLevel;
    public TMP_Text txtName;
    public TMP_Text txtGold;

    private void Start()
    {
        RefreshState();
    }

    public void RefreshState()
    {
        var character = GameManager.GetInstance().GetCharacterIdx();

        txtLevel.text = $"Lv. {character.level}";
        txtName.text = $"{character.playerName}";
        txtGold.text = $"{character.gold} G";

        hpBar.maxValue = character.totalhp;
        hpBar.value = character.curhp;
        txtHp.text = $"{hpBar.value}/{hpBar.maxValue}";
    }
}