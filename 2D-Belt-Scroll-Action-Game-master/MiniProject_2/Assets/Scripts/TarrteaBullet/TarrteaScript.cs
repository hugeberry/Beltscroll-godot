using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//총알 발사용 스크립트
public class TarrteaScript : MonoBehaviour
{
   public void AttackTarrtea()
    {
        Soundtrack.TarreaAttack();
        BulletArray.AttackBullet(transform);
    }
}
