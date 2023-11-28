using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinArray : MonoBehaviour
{
    private static ArrayObject<GameObject> coin;
    private static int coinCount;

    //몬스터 배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        coinCount = 0;
        coin = new ArrayObject<GameObject>();

        GameObject coinArr = GameObject.FindWithTag("CoinArray");

        for (int i = 0; i < coinArr.transform.childCount; i++)
        {
            coin.add(coinArr.transform.GetChild(i).gameObject);
        }
    }

    //몬스터 리스폰
    public static GameObject DropTheCoin(Transform location)
    {
        if (coinCount == coin.length)
            coinCount = 0;

        GameObject crrentCoin = coin.get(coinCount++);
        crrentCoin.transform.position = location.position;
        crrentCoin.SetActive(true);

        return crrentCoin;  
    }
}
