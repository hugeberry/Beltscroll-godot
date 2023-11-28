using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFSM
{
    public class Head_Machine<T>
    {
        private T Owner;

        private FSM<T> m_CurState = null; //현재
        private FSM<T> m_PrevState = null; //이전


        public void Begin()
        {
            if(m_CurState != null)
            {
                m_CurState.Begin();
            }

        }
        public void Run()
        {
            CheckState();
        }

        public void CheckState()
        {
            if(m_CurState != null)
            {
                m_CurState.Run();
            }
        }

        public void Exit()
        {
            m_CurState.Exit();
            m_CurState = null;
            m_PrevState = null;
        }

        public void Change(FSM<T> _state)
        {
            //같은 상태 변화 는 리턴
            if (_state == m_CurState)
                return;

            m_PrevState = m_CurState; //이전 상태로 돌림

            //현재 상태가 있다면 종료
            if (m_CurState != null)
                m_CurState.Exit();

            m_CurState = _state;

            //새로 적용된 상태가 널이 아니면 실행
            if (m_CurState != null)
                m_CurState.Begin();
        }

        //변화할떈 아무런 인자값이 없으면 전에 상태값을 출력한다
        public void Revert()
        {
            if (m_PrevState != null)
                Change(m_PrevState);
        }

        //상태값 세팅
        public void SetState(FSM<T> _state, T _Owner)
        {
            Owner = _Owner;
            m_CurState = _state;

            //들어온 상태값이 지금과 다를떄, 현재상태값이 채워져 있을때
            if (m_CurState != _state && m_CurState != null)
                m_PrevState = m_CurState;
        }
           
    }
}
