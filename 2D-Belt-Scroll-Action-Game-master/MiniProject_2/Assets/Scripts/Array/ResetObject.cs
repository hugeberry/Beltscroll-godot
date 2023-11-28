using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 시작시 오브젝트 풀링 초기화
public class ResetObject : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine("ObjectPulling");
        StartCoroutine("UiPulling");
        WeaponArray.Initalize();
        SubWeaponArray.Initalize();
        BulletArray.Initalize();
        CoinArray.Initalize();
        PotionArray.Initalize();
    }

    IEnumerator UiPulling()
    {
        CreateHealText.Initalize();
        CreateCoinText.Initalize();
        CreateDamageText.Initalize();
        yield return null;
    }

    IEnumerator ObjectPulling()
    {
        BurgyArray.Initalize();
        TarrteaArray.Initalize();
        TracanArray.Initalize();
        LightningArray.Initalize();
        MeteorArray.Initalize();
        WaveArray.Initalize();
        LaserArray.Initalize();
        yield return null;
    }
}
