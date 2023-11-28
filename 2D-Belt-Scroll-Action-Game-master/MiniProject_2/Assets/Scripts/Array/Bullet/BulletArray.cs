using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//타르티 총알 받아올 스크립트 오브젝트 풀링
public class BulletArray : MonoBehaviour
{
    private static ArrayObject<GameObject> bullet;
    private static int bulletCount;

    //총알 배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        bulletCount = 0;
        bullet = new ArrayObject<GameObject>();

        Transform bulletParent = GameObject.Find("Bullet").transform;

        for (int i = 0; i < bulletParent.childCount; i++)
        {
            bullet.add(bulletParent.transform.GetChild(i).gameObject);
        }
    }

    //총알 스폰
    public static void AttackBullet(Transform location)
    {
        if (bulletCount == bullet.length)
            bulletCount = 0;

        float forword = location.localScale.x == -1 ? 90f : -90f; //스케일에 따라 이동 방향
        float dirX = location.localScale.x == -1 ? -1.5f : 1.5f; //스케일에 따라 방향바뀜

        GameObject mon = bullet.get(bulletCount++);
        BulletScript bulletScript = mon.GetComponent<BulletScript>();

        mon.transform.rotation = Quaternion.Euler(new Vector3(0,0, forword));
        mon.transform.position = new Vector3(location.position.x + dirX, location.position.y + 1.5f,location.position.z);
        bulletScript.Attack = location.GetComponent<MonsterFSM>().ATK;
        mon.SetActive(true);
    }
}