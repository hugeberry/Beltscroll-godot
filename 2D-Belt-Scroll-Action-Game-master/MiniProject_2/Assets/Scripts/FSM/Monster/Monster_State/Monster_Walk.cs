using MyFSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Walk : FSM<MonsterFSM>
{
    //주인 변수
    private MonsterFSM m_Owner;
    //네비 메시 에이전트
    private NavMeshAgent agent;
    //애니메이터
    private Animator m_Animator;

    //생성자
    public Monster_Walk(MonsterFSM _owner)
    {
        m_Owner = _owner;
    }

    //시작
    public override void Begin()
    {
        agent = m_Owner.GetComponent<NavMeshAgent>();
        agent.isStopped = false;
        m_Owner.m_eCurState = MONSTER_STATE.Walk;
        m_Animator = m_Owner.m_Animator;
        m_Animator.Play("Move");
    }

    //동작
    public override void Run()
    {
        if(m_Owner.m_TransTarget == null)
        {
            m_Owner.ChangeFSM(MONSTER_STATE.Idle);
        }
        if (m_Owner.m_TransTarget != null)
            GoToTarget();
    }

    //종료
    public override void Exit()
    {
        agent.isStopped = true;
        m_Owner.m_ePrevState = MONSTER_STATE.Walk;
        m_Animator.SetBool("isMove", false);
    }

    private void GoToTarget()
    {
        agent.SetDestination(m_Owner.m_TransTarget.position);
    }
}