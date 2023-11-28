using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//데미지 텍스트 오브젝트 풀링
public class CreateDamageText : MonoBehaviour
{
    private static int DamageTextCount;

    private static ArrayObject<Transform> damageText; //테미지 택스트 파티클
    private static ArrayObject<GameObject> HitPhysics; //일반 피격 파티클
    private static ArrayObject<GameObject> explosion; //폭팔 파티클
    private static GameObject canvas;

    //데미지 텍스트 초기화
    public static void Initalize()
    {
        DamageTextCount = 0;
        canvas = GameObject.Find("Canvas");
        damageText = new ArrayObject<Transform>();
        HitPhysics = new ArrayObject<GameObject>();
        explosion = new ArrayObject<GameObject>();

        Transform DT = canvas.transform.Find("DamageText");
        GameObject FindHitPhysics = GameObject.Find("HitPhysics");
        Transform explosionParent = GameObject.Find("Explosion").transform;

        for (int i = 0; i < DT.childCount; i++)
        {
            damageText.add(DT.GetChild(i));
            HitPhysics.add(FindHitPhysics.transform.GetChild(i).gameObject);
            explosion.add(explosionParent.transform.GetChild(i).gameObject);
        }
    }

    //데미지 텍스트 생성.
    public static void CreateText(string damage, string ex, Transform location)
    {
        GameObject hitParticle;

        if (DamageTextCount == damageText.length)
            DamageTextCount = 0;

        if (ex == "explosion")  //매개변수 ex가 explosion이면 폭팔 파티클 아니면 일반 피격 파티클
            hitParticle = explosion.get(DamageTextCount);
        else
            hitParticle = HitPhysics.get(DamageTextCount);

        DamageText instance = damageText.get(DamageTextCount++).GetComponent<DamageText>();
        hitParticle.transform.position = location.position;
        hitParticle.SetActive(true);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-1f,1f), location.position.y+1f + Random.Range(-1f, 1f)));
        instance.gameObject.SetActive(true);
        instance.transform.position = screenPosition;

        instance.SetText(damage);
    }
}