using MyFSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Watch : FSM<MonsterFSM>
{
    private float coolTime = 5;

    //주인 변수
    private MonsterFSM m_Owner;
    //애니메이터
    private Animator m_Animator;

    private float dirX;
    private float dirY;

    //생성자
    public Monster_Watch(MonsterFSM _owner)
    {
        m_Owner = _owner;
    }

    //시작
    public override void Begin()
    {
        m_Owner.m_eCurState = MONSTER_STATE.Watch;
        m_Animator = m_Owner.m_Animator;
    }

    //동작
    public override void Run()
    {
        FindRange();

        if (m_Owner.m_TransTarget == null)
        {
            m_Owner.ChangeFSM(MONSTER_STATE.Idle);
        }
        if (m_Owner.m_TransTarget != null)
            if(coolTime > 2f)
            {
                m_Animator.SetBool("isMove", true);
                GoToSearch(dirX, dirY);
            }
        if(coolTime  > 4f)
        {
            int randomState = Random.Range(1, 4);

            if (randomState == 1)
                m_Owner.ChangeFSM(MONSTER_STATE.Attack);
            else
            {
                m_Animator.SetBool("isMove", false);
                dirX = Random.Range(-1, 2);
                dirY = Random.Range(-1, 2);
                coolTime = 0f;
            }
        }
        coolTime += Time.deltaTime;
    }

    //종료
    public override void Exit()
    {
        dirX = -dirX; dirY = -dirY;
        m_Owner.m_ePrevState = MONSTER_STATE.Watch;
        m_Animator.SetBool("isMove", false);
    }

    //공격범위 찾기
    private void FindRange()
    {
        Collider[] hitColliders = Physics.OverlapBox(m_Owner.transform.position, m_Owner.m_AttackArea / 2);

        if (hitColliders.Length != 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    m_Owner.ChangeFSM(MONSTER_STATE.Attack);
                    Exit();
                }
            }
        }
    }


    public void GoToSearch(float dirX, float dirY)
    {
        m_Owner.transform.position += new Vector3(dirX * 3f * Time.deltaTime, 0f, dirY * 3f * Time.deltaTime);
    }
}
