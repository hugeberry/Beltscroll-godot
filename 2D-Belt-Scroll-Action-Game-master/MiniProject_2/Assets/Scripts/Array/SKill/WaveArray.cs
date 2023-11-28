using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//워터 웨이브 배열
public class WaveArray : MonoBehaviour
{
    private static ArrayObject<GameObject> wave;
    private static int skillCount;

    //배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        skillCount = 0;
        wave = new ArrayObject<GameObject>();

        Transform lightParent = GameObject.Find("WaveArray").transform;

        for (int i = 0; i < lightParent.childCount; i++)
        {
            wave.add(lightParent.transform.GetChild(i).gameObject);
        }
    }

    //웨이브 스폰
    public static void WaveSpone(Transform location)
    {
        Vector3 position = location.position;
        Vector3 scale = new Vector3(2, 2, 2);

        if (location.transform.localScale.x == 1)
        {
            position.x = location.transform.position.x + 5;
            scale.z = 2;
        }
        else
        {
            position.x = location.transform.position.x - 5;
            scale.z = -2;
        }

        if (skillCount == wave.length)
            skillCount = 0;

        GameObject skill = wave.get(skillCount++);
        skill.transform.position = position;
        skill.transform.localScale = scale;
        skill.SetActive(true);
    }
}
