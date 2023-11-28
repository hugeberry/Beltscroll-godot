using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//스킬스크립트 <번개>
public class Lightning : AbstractSkill //상속함
{
    public override void SkillAttak()//스킬 어택 방식
    {
        int i = 0;
        Collider[] coll = Physics.OverlapBox(skillPoint.transform.position, skillRange/2);
        foreach (Collider collider in coll)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Soundtrack.LightningSound();
                LightningArray.LightNingAttak(collider.gameObject.transform);
                collider.GetComponent<MonsterFSM>().TakeDamage( skill_INT , true);
                i++;
            }
            else if(collider.gameObject.layer == LayerMask.NameToLayer("Boss"))
            {
                Soundtrack.LightningSound();
                LightningArray.LightNingAttak(collider.gameObject.transform);
                collider.GetComponent<BossSkill>().TakeDamage(skill_INT);
                i++;
            }
            if (i == skill_INT / 5) //능력치에따라 맞는 적의 수가 늘어남 최소 3명
                break;
        }
    }
}
