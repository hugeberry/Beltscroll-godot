using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//스킬스크립트 <웨이브>
public class WaterWave : AbstractSkill //상속함
{
    public override void SkillAttak()//스킬 어택 방식
    {
        WaveAttak.waveDamage = (int)(skill_INT * 0.8f);
        WaveArray.WaveSpone(player.transform);
    }
}
