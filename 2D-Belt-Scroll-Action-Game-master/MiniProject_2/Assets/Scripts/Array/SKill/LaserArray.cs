using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//레이저 배열
public class LaserArray : MonoBehaviour
{
    private static ArrayObject<GameObject> laser;
    private static int skillCount;

    //배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        skillCount = 0;
        laser = new ArrayObject<GameObject>();

        Transform lightParent = GameObject.Find("LaserArray").transform;

        for (int i = 0; i < lightParent.childCount; i++)
        {
            laser.add(lightParent.transform.GetChild(i).gameObject);
        }
    }

    //레이저 스폰
    public static void LaserSpone(Transform location)
    {
        Vector3 position = location.position;
        Vector3 scale = new Vector3(3, 3, 3);

        if (location.transform.localScale.x == 1)
        {
            position.x = location.transform.position.x + 4;
            scale.x = 3;
        }
        else
        {
            position.x = location.transform.position.x - 4;
            scale.x = -3;
        }

        if (skillCount == laser.length)
            skillCount = 0;

        GameObject skill = laser.get(skillCount++);
        skill.transform.position = position;
        skill.transform.localScale = scale;
        skill.SetActive(true);
    }
}
