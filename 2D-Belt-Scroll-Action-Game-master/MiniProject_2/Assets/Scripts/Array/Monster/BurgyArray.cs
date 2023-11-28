using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using ArrayPulling;
using UnityEngine;

//몬스터 오브젝트 풀링<버기>
public class BurgyArray : MonoBehaviour
{

    private static ArrayObject<GameObject> burgyArr;
    private static int burgyCount;

    //몬스터 배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        burgyCount = 0;
        burgyArr = new ArrayObject<GameObject>();

        GameObject burgy = GameObject.FindWithTag("BurgyArray");

        for (int i = 0; i < burgy.transform.childCount; i++)
        {
            burgyArr.add(burgy.transform.GetChild(i).gameObject);
        }
    }

    //몬스터 리스폰
    public static void ResponeBurgy(Transform location, int many)
    {
        for (int i = 0; i < many; i++)
        {
            if (burgyCount >= burgyArr.length)
                burgyCount = 0;

            GameObject mon = burgyArr.get(burgyCount++);
            if (!mon.activeSelf)
            {
                mon.transform.position = location.position;
                mon.GetComponent<NavMeshAgent>().baseOffset = 0;
                mon.SetActive(true);
            }
        }
    }
}