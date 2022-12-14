using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerprefControl : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("testkey", 2);
        Debug.Log(PlayerPrefs.HasKey("testkey")); //가지고 있으니까 값은 True
        Debug.Log(PlayerPrefs.GetInt("testkey")); //키값인 2
    }

    void Update()
    {
        
    }
}