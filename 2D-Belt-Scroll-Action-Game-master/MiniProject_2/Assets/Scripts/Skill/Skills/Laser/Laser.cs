using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//스킬스크립트 <레이저>
public class Laser : AbstractSkill //상속함
{
    public override void SkillAttak()//스킬 어택 방식
    {
        Collider[] coll = Physics.OverlapBox(laserPos.transform.position, skillRange / 2);
        Soundtrack.Laser();
        LaserArray.LaserSpone(player.transform);
        foreach (Collider collider in coll)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy") || collider.gameObject.layer == LayerMask.NameToLayer("Boss"))
            {
                StartCoroutine("AttackCoroutine", collider);
            }
        }
    }

    IEnumerator AttackCoroutine(Collider collider)
    {
        int length = skill_INT / 8;
        if (collider.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            for (int i = 0; i < length; i++)
            {
                collider.GetComponent<BossSkill>().TakeDamage(skill_INT);
                yield return new WaitForSeconds(0.1f);
            }

        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                collider.GetComponent<MonsterFSM>().TakeDamage(skill_INT, false);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
