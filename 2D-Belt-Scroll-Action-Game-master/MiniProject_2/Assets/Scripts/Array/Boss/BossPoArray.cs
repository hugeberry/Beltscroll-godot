using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//3스테이지 보스 쓰레기  배열
public class BossPoArray : MonoBehaviour
{
    private static ArrayObject<GameObject> trash;
    private static int skillCount;

    //배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        skillCount = 0;
        trash = new ArrayObject<GameObject>();

        Transform trashA = GameObject.Find("TrashArray").transform;

        for (int i = 0; i < trashA.childCount; i++)
        {
            trash.add(trashA.transform.GetChild(i).gameObject);
        }
    }

    //메테오 스폰
    public static void TrashSpone(Vector3 location)
    {
        if (skillCount == trash.length)
            skillCount = 0;

        GameObject skill = trash.get(skillCount++);
        skill.transform.position = location;
        skill.SetActive(true);
    }

    public static int get()
    {
        return trash.length;
    }
}
