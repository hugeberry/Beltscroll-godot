using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using ArrayPulling;
using UnityEngine;

//코인텍스트 오브젝트 풀링
public class CreateHealText : MonoBehaviour
{
    private static int HealTextcount;

    private static ArrayObject<Transform> healText;
    private static ArrayObject<GameObject> healImpect;
    private static GameObject canvas;

    //데미지 텍스트 초기화
    public static void Initalize()
    {
        HealTextcount = 0;
        canvas = GameObject.Find("Canvas");
        healText = new ArrayObject<Transform>();
        healImpect = new ArrayObject<GameObject>();

        Transform HT = canvas.transform.Find("HealText");
        Transform HI = GameObject.Find("HealArray").transform;

        for (int i = 0; i < HT.childCount; i++)
        {
            healText.add(HT.GetChild(i));
            healImpect.add(HI.GetChild(i).gameObject);
        }
    }

    //데미지 텍스트 생성.
    public static void CreateText(int heal, Transform location)
    {
        if (HealTextcount == healText.length)
            HealTextcount = 0;

        HealText instance = healText.get(HealTextcount).GetComponent<HealText>();
        GameObject HealParticle = healImpect.get(HealTextcount++);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.5f, .5f), location.position.y + 1f + Random.Range(-.5f, .5f)));

        HealParticle.transform.position = new Vector3(location.position.x+1,location.position.y-2,location.position.z);
        HealParticle.SetActive(true);

        instance.gameObject.SetActive(true);
        instance.transform.position = screenPosition;
        instance.SetText(heal);
    }
}