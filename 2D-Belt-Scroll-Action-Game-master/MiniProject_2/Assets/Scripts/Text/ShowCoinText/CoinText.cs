using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//코인텍스트 스크립트
public class CoinText : MonoBehaviour
{
    public Animator anim;
    private Text coinText;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0); //애니메이션 클립 받아옴
        if (clipInfo[0].clip.length - 0.1f > 0.9f) //길이가 0.9보다 크다면. -0.1은 안주면 작동이 안될 경우도 있기에 여유분으로 넗어줌
        {
            gameObject.SetActive(false); //없앰
            transform.position = new Vector3(-781f, -60f, 0f); //위치 이동
        }
        coinText = anim.GetComponent<Text>();
    }

    public void OffActive()
    {
        gameObject.SetActive(false);
    }

    public void SetText(int coin)
    {
        anim.GetComponent<Text>().text = coin.ToString();
    }
}
