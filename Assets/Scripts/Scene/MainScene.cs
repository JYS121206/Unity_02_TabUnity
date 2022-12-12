using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    static Animator characterAnimator;
    void Start()
    {
        UIManager uimanager = UIManager.GetInstance();
        uimanager.SetEventSystem();
        uimanager.OpenUI("UIProfile");
        uimanager.OpenUI("UIActionMenu");

        GameObject go = ObjectManager.GetInstance().CreateCharacter();
        go.transform.localScale = new Vector3(2, 2, 2);
        go.transform.localPosition = new Vector3(0, 1.1f, 0);

        characterAnimator = go.GetComponent<Animator>();
    }

     static public void PlayAnimation()
    {
        characterAnimator.SetTrigger("Attack");
    }
}