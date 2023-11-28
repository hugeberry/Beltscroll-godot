using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스킬스크립트 <메테오>
public class Meteor : AbstractSkill
{
    public GameObject obj;
    public override void SkillAttak()
    {
        Soundtrack.MeteorStart();
        for (int i = 0; i < skill_INT / 5; i++)
        {
            float x = Random.Range(-60f, -10f) + skillPoint.transform.position.x;
            float z = Random.Range(-skillRange.z, skillRange.z / 2) ;

            MeteorArray.MeteorSpone(new Vector3(x, 20f, z));
        }
    }
}
