using MyFSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//몬스터 데미지 받을때 스크립트
public class Monster_TakeDamage : FSM<MonsterFSM>
{
    //주인 변수
    private MonsterFSM m_Owner;

    //생성자
    public Monster_TakeDamage(MonsterFSM _owner)
    {
        m_Owner = _owner;
    }


    public override void Begin()
    {
        if (m_Owner.enemyName == MONSTER_NAME.BURGY)
        {
            Soundtrack.burgyDamage();
        }
        else if (m_Owner.enemyName == MONSTER_NAME.TARRTEA)
        {
            Soundtrack.TarrteaDamage();
        }
        else if (m_Owner.enemyName == MONSTER_NAME.TRACAN)
        {
            Soundtrack.TracanHit();
        }
        m_Owner.isAttack = true;
    }

    public override void Run()
    {
    }

    public override void Exit()
    {
        m_Owner.m_ePrevState = MONSTER_STATE.TakeDamage;
    }

}
