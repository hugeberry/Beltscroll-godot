using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//타르티 배열
public class TarrteaArray : MonoBehaviour
{
    private static ArrayObject<GameObject> TarrteaArr;
    private static int TarrteaCount;

    //몬스터 배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        TarrteaCount = 0;
        TarrteaArr = new ArrayObject<GameObject>();

        GameObject tarrtea = GameObject.FindWithTag("TarrteaArray");

        for (int i = 0; i < tarrtea.transform.childCount; i++)
        {
            TarrteaArr.add(tarrtea.transform.GetChild(i).gameObject);
        }
    }

    //몬스터 리스폰
    public static void ResponeTarrtea(Transform location,int many)
    {
        for (int i = 0; i < many; i++)
        {
            if (TarrteaCount >= TarrteaArr.length)
                TarrteaCount = 0;

            GameObject mon = TarrteaArr.get(TarrteaCount++);
            if (!mon.activeSelf)
            {
                mon.transform.position = location.position;
                mon.GetComponent<NavMeshAgent>().baseOffset = 0;
                mon.SetActive(true);
            }
        }
    }
}
