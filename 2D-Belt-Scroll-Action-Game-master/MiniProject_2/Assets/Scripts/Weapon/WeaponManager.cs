using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//무기 스크립트
public class WeaponManager : ItemManager
{
    //무기 스탯
    public int ATK = 0;
    public int INT = 0;//해당 무기의 능지 수치
    public int comboPlusDamage = 0; //콤보대미지용

    private int currentATK; // 스크립트용 공격력

    public void Attack() //애니메이션용 함수
    {
        int count = 0; //최대 맞출수있는 적의 수
        Collider[] coll = Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size);
        foreach (Collider collider in coll)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                bool isBound = false;
                if (comboPlusDamage >= 3)
                {
                    isBound = true;
                    Soundtrack.ATTACK3();
                }
                else
                    Soundtrack.ATTACK12();

                collider.GetComponent<MonsterFSM>().TakeDamage(currentATK + comboPlusDamage, isBound);
                count++;
            }
            else if (collider.gameObject.layer == LayerMask.NameToLayer("Boss"))
            {
                collider.GetComponent<BossSkill>().TakeDamage(currentATK + comboPlusDamage);
            }
            else
            {
                Soundtrack.PlayerAttackMiss();
            }
            if (count == 4)
                break;

        }
        count = 0;
    }

    public int getAtk() { return ATK; } //무기 공격력 반환

    public void setAtk(int atk) { currentATK = ATK + atk; } //무기 공격력 세팅 공격할때 사용함.
}