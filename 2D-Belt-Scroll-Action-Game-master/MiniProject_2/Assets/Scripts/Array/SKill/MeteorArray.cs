using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//메테오 배열
public class MeteorArray : MonoBehaviour
{
    private static ArrayObject<GameObject> meteor;
    private static int skillCount;

    //배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        skillCount = 0;
        meteor = new ArrayObject<GameObject>();

        Transform lightParent = GameObject.Find("MeteorArray").transform;

        for (int i = 0; i < lightParent.childCount; i++)
        {
            meteor.add(lightParent.transform.GetChild(i).gameObject);
        }
    }

    //메테오 스폰
    public static void MeteorSpone(Vector3 location)
    {
        if (skillCount == meteor.length)
            skillCount = 0;

        GameObject skill = meteor.get(skillCount++);
        skill.transform.position = location;
        skill.SetActive(true);
    }

    public static int get()
    {
        return meteor.length;
    }
}
