using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapon : ItemManager
{

    public Vector3 skillRange;

    //status
    public int plusHP;
    public int plusMP;
    public int plusATK;
    public int plusINT;
    public int plusDEF;

    private GameObject pos;
    private GameObject laserPos;
    private GameObject player;
    public AbstractSkill skill;

    private void OnEnable()
    {
        pos = GameObject.FindWithTag("SkillPoint");
        player = GameObject.Find("PlayerParent").transform.GetChild(0).gameObject;
        laserPos = GameObject.Find("PlayerParent").transform.GetChild(0).Find("LaserPosition").gameObject; ;
        skill = GetComponent<AbstractSkill>();
    }

    public void SetSkillDamage(int damage)
    {
        skill.SetSubSkill(damage, skillRange);
        skill.skillPoint = pos;
        skill.player = player;
        skill.laserPos = laserPos;
        skill.SkillAttak();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(pos != null)
            Gizmos.DrawWireCube(pos.transform.position, skillRange);
        Gizmos.color = Color.black;
        if (player != null)
            Gizmos.DrawWireCube(laserPos.transform.position, skillRange);
    }
}
