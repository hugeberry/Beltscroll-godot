using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

//데미지 텍스트 스크립트
public class DamageText : MonoBehaviour
{
    public Animator anim;
    private Text damageText;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
        if (clipInfo[0].clip.length - 0.1f > 0.9f)
        {
            gameObject.SetActive(false);
            transform.position = new Vector3(-781f, 0f, 0f);
        }
        damageText = anim.GetComponent<Text>();
    }

    public void OffActive()
    {
        gameObject.SetActive(false);
    }

    public void SetText(String damage)
    {
        anim.GetComponent<Text>().text = damage;
    }
}
