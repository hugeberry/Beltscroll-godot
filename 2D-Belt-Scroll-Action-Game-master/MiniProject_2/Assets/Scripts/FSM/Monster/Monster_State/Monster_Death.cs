using MyFSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//몬스터 사망 스크립트
public class Monster_Death : FSM<MonsterFSM>
{

    //주인 변수
    private MonsterFSM m_Owner;

    //생성자
    public Monster_Death(MonsterFSM _owner)
    {
        m_Owner = _owner;
    }


    public override void Begin()
    {
        if (m_Owner.enemyName == MONSTER_NAME.BURGY)
        {
            Soundtrack.burgyDie();
        }
        else if (m_Owner.enemyName == MONSTER_NAME.TARRTEA)
        {
            Soundtrack.TarrteaDie();
        }
        else if (m_Owner.enemyName == MONSTER_NAME.TRACAN)
        {
            Soundtrack.TracanDie();
        }
        CameraPrison.dieCount++;
        m_Owner.m_eCurState = MONSTER_STATE.Death;
        m_Owner.m_Animator.Play("Death");
    }

    public override void Exit()
    {

    }

    public override void Run()
    {
    }
}
