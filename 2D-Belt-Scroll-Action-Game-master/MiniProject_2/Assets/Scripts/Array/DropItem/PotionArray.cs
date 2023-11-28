using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionArray : MonoBehaviour
{
    private static ArrayObject<GameObject> potion;
    private static int potionCount;

    //몬스터 배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        potionCount = 0;
        potion = new ArrayObject<GameObject>();

        GameObject coinArr = GameObject.FindWithTag("PotionArray");

        for (int i = 0; i < coinArr.transform.childCount; i++)
        {
            potion.add(coinArr.transform.GetChild(i).gameObject);
        }
    }

    //몬스터 리스폰
    public static GameObject DropThePotion(Transform location)
    {
        if (potionCount == potion.length)
            potionCount = 0;

        GameObject crrentPotion = potion.get(potionCount++);
        crrentPotion.transform.position = location.position;
        crrentPotion.SetActive(true);

        return crrentPotion;
    }
}
