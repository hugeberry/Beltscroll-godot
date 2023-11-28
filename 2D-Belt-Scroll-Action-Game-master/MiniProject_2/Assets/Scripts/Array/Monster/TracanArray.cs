using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//트라켄 배열
public class TracanArray : MonoBehaviour
{
    private static ArrayObject<GameObject> TracanArr;
    private static int Tracancount;

    //몬스터 배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        Tracancount = 0;
        TracanArr = new ArrayObject<GameObject>();

        GameObject tarrtea = GameObject.FindWithTag("TracanArray");

        for (int i = 0; i < tarrtea.transform.childCount; i++)
        {
            TracanArr.add(tarrtea.transform.GetChild(i).gameObject);
        }
    }

    //몬스터 리스폰
    public static void ResponeTracan(Transform location, int many)
    {
        for (int i = 0; i < many; i++)
        {
            if (Tracancount >= TracanArr.length)
                Tracancount = 0;

            GameObject mon = TracanArr.get(Tracancount++);
            if (!mon.activeSelf)
            {
                mon.transform.position = location.position;
                mon.GetComponent<NavMeshAgent>().baseOffset = 0;
                mon.SetActive(true);
            }
        }
    }
}
