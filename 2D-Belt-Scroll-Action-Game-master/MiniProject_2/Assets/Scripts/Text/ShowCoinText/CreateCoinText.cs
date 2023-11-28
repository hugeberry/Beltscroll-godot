using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using ArrayPulling;
using UnityEngine;

//코인텍스트 오브젝트 풀링
public class CreateCoinText : MonoBehaviour
{
    private static int CoinTextcount;

    private static ArrayObject<Transform> coinText;
    private static GameObject canvas;
       
    //데미지 텍스트 초기화
    public static void Initalize()
    {
        CoinTextcount = 0;
        canvas = GameObject.Find("Canvas");
        coinText = new ArrayObject<Transform>();

        Transform CT = canvas.transform.Find("CoinText");

        for (int i = 0; i < CT.childCount; i++)
        {
            coinText.add(CT.GetChild(i));
        }
    }

    //데미지 텍스트 생성.
    public static void CreateText(int coin, Transform location)
    {
        if(CoinTextcount == coinText.length)
            CoinTextcount = 0;

        CoinText instance = coinText.get(CoinTextcount++).GetComponent<CoinText>();
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.5f, .5f), location.position.y + 1f + Random.Range(-.5f, .5f)));
        
        instance.gameObject.SetActive(true);
        instance.transform.position = screenPosition;
        instance.SetText(coin);
    }
}