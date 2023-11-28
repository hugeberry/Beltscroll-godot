using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//몬스터 기본 자세스크립트
namespace MyFSM
{
    public class Monster_Idle : FSM<MonsterFSM>
    {
        private MonsterFSM m_Owner;

        public Monster_Idle(MonsterFSM _owner)
        {
            m_Owner = _owner;
        }

        public override void Begin()
        {
            m_Owner.m_eCurState = MONSTER_STATE.Idle;
        }

        public override void Run()
        {
            FindRange();
            if (m_Owner.m_TransTarget != null)
            {
                int randomState = Random.Range(1, 4);

                if (randomState == 1)
                    m_Owner.ChangeFSM(MONSTER_STATE.Attack);
                else
                    m_Owner.ChangeFSM(MONSTER_STATE.Walk);
            }
        }

        public override void Exit()
        {
            m_Owner.m_ePrevState = MONSTER_STATE.Idle;
        }

        private void FindRange()
        {
            Collider[] hitColliders = Physics.OverlapBox(m_Owner.transform.position, m_Owner.m_FindRange/2);

            if (hitColliders.Length != 0)
            {
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (hitColliders[i].gameObject.tag == "Player")
                    {
                        m_Owner.m_TransTarget = hitColliders[i].transform;
                    }
                }
            }
        }
    }
}