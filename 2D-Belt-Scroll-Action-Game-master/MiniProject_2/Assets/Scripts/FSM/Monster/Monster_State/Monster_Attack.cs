using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFSM;
using UnityEngine.AI;

public class Monster_Attack : FSM<MonsterFSM>
{
    //주인 변수
    private MonsterFSM m_Owner;
    //네비 메시 에이전트
    private NavMeshAgent agent;
    //애니메이터
    private Animator m_Animator;

    private Vector3 ranges = Vector3.zero; //트라켄과 다른 몬스터의 차별화된 공격사거리를 위해 넣은 변수
    //생성자
    public Monster_Attack(MonsterFSM _owner)
    {
        m_Owner = _owner;
    }

    //시작
    public override void Begin()
    {
        agent = m_Owner.GetComponent<NavMeshAgent>();
        m_Owner.m_eCurState = MONSTER_STATE.Attack;
        m_Animator = m_Owner.m_Animator;
        m_Owner.isAttack = false;

        ranges = m_Owner.enemyName == MONSTER_NAME.TRACAN ? m_Owner.m_AttackArea : m_Owner.m_AttackRange;
        //애니메이션 트리거 or bool true
    }

    //동작
    public override void Run()
    {
        if (m_Owner.m_TransTarget == null)
        {
            m_Owner.ChangeFSM(MONSTER_STATE.Idle);
        }

        if (m_Owner.m_TransTarget != null)
        {
            if (!m_Owner.isAttack && FindRange(ranges))
            {
                agent.isStopped = true;
                m_Owner.isAttack = true;
                m_Animator.SetBool("isMove", false);
                m_Animator.Play("Attack");
            }
            else if (m_Owner.isAttack && m_Owner.enemyName == MONSTER_NAME.TRACAN)
            {
                if (m_Owner.isStop)
                    m_Owner.transform.Translate(new Vector3(m_Owner.dir, 0f, 0f) * 25f * Time.deltaTime);
            }
            else if (!m_Owner.isAttack)
            {
                agent.isStopped = false;
                m_Animator.SetBool("isMove", true);
                GoToTarget();
            }
        }

    }

    //공격 범위
    private bool FindRange(Vector3 range)
    {
        Collider[] hitColliders = Physics.OverlapBox(m_Owner.transform.position, range / 2);

        if (hitColliders.Length != 0)
        {
            foreach (Collider collider in hitColliders)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }


    //종료
    public override void Exit()
    { 
        agent.isStopped = true;
        m_Owner.m_ePrevState = MONSTER_STATE.Attack;
        //애니메이션 트리거 or bool false
    }

    //공격 할 수 있는 위치로 이동
    private void GoToTarget()
    {
        float dirX = (m_Owner.transform.position.x < m_Owner.m_TransTarget.position.x) ? -1 : 1;
        agent.SetDestination(new Vector3(m_Owner.m_TransTarget.position.x + (dirX * m_Owner.attackR), m_Owner.m_TransTarget.position.y, m_Owner.m_TransTarget.position.z));
    }
}
