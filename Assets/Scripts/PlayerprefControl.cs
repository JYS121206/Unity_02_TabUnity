using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerprefControl : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("testkey", 2);
        Debug.Log(PlayerPrefs.HasKey("testkey")); //������ �����ϱ� ���� True
        Debug.Log(PlayerPrefs.GetInt("testkey")); //Ű���� 2
    }

    void Update()
    {
        
    }
}