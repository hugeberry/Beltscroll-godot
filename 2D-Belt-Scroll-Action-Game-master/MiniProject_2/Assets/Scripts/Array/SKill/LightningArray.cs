using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//라이트닝 배열
public class LightningArray : MonoBehaviour
{
    private static ArrayObject<GameObject> lightning;
    private static int skillCount;

    //총알 배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        skillCount = 0;
        lightning = new ArrayObject<GameObject>();

        Transform lightParent = GameObject.Find("LightningArray").transform;

        for (int i = 0; i < lightParent.childCount; i++)
        {
            lightning.add(lightParent.transform.GetChild(i).gameObject);
        }
    }

    //총알 스폰
    public static void LightNingAttak(Transform location)
    {
        if (skillCount == lightning.length)
            skillCount = 0;

        GameObject skill = lightning.get(skillCount++);
        skill.transform.position = location.position;
        skill.SetActive(true);
    }

    public static int get()
    {
        return lightning.length;
    }
}
