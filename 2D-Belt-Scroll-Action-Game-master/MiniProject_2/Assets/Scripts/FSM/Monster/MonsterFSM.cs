using MyFSM;
using UnityEngine;
using UnityEngine.AI;

//몬스터 스크립트
public class MonsterFSM : MonoBehaviour
{
    public MONSTER_NAME enemyName; // 적이름
    public int MaxHP; // 최대 피통
    private int HP; //피통
    public int ATK; //공격력
    public float attackR; //공격사거리(이동할떄 필요)
    private int DEF; //몬스터의 방어력 랜덤으로 정할거임

    //머신에 들어갈 스테이트
    public Head_Machine<MonsterFSM> m_state;
    //몬스터가 미리 가지고 있을 스테이트
    public FSM<MonsterFSM>[] m_arrState = new FSM<MonsterFSM>[(int)MONSTER_STATE.Lenght];

    //몬스터가 다른 오브젝트를 찾을 범위
    public Vector3 m_FindRange;
    //몬스터가 찾은 타겟
    public Transform m_TransTarget;

    //몬스터의 현재 상태, 이전상태 표시용
    public MONSTER_STATE m_eCurState;
    public MONSTER_STATE m_ePrevState;

    //몬스터의 공격상태 변화 범위
    public Vector3 m_AttackArea;
    //몬스터의 공격 사정거리
    public Vector3 m_AttackRange;

    //공격할때 멈추게함
    [HideInInspector] public bool isAttack = false; //움식임이나 행동을 멈춤
    [HideInInspector] public bool isStop = false; //트라켄의 돌진공격할때 쓰일 변수
    [HideInInspector] public int dir = 0; //방향을 조정할떄 쓰일 변수

    //애니메이터
    [HideInInspector] public Animator m_Animator;

    //생성자
    public MonsterFSM()
    {
        Init();
    }

    //필요한 데이터 초기화
    public void Init()
    {
        HP = MaxHP;

        m_state = new Head_Machine<MonsterFSM>();
        m_arrState[(int)MONSTER_STATE.Idle] = new Monster_Idle(this);
        m_arrState[(int)MONSTER_STATE.Walk] = new Monster_Walk(this);
        m_arrState[(int)MONSTER_STATE.Attack] = new Monster_Attack(this);
        m_arrState[(int)MONSTER_STATE.Watch] = new Monster_Watch(this);
        m_arrState[(int)MONSTER_STATE.TakeDamage] = new Monster_TakeDamage(this);
        m_arrState[(int)MONSTER_STATE.Death] = new Monster_Death(this);

        m_state.SetState(m_arrState[(int)MONSTER_STATE.Idle], this);
    }

    //상태 변화 함수
    public void ChangeFSM(MONSTER_STATE ps)
    {
        m_state.Exit();
        for (int i = 0; i < (int)MONSTER_STATE.Lenght; ++i)
        {
            if (i == (int)ps)
                m_state.Change(m_arrState[(int)ps]);
        }
    }

    //데미지 받았을때 실행할 함수
    public void TakeDamage(int damage, bool bound)
    {
        if (bound)
        {
            float scale = transform.localScale.x == 1 ? -0.5f : 0.5f;
            GetComponent<Rigidbody>().AddForce(new Vector3(scale, 2, 0) * 4000);
        }
        CreateDamageText.CreateText((damage - DEF).ToString(), "", transform);

        HP -= damage - DEF;
        if (isStop == false)
        {
            m_Animator.Play("Damaged");
            ChangeFSM(MONSTER_STATE.TakeDamage);
        }
    }

    //죽었을때 코인 드랍함. 애니메이션용 함수
    public void DropCoin()
    {
        int random = Random.Range(1, 10);
        if (random != 2)
        {
            GameObject coin = CoinArray.DropTheCoin( gameObject.transform );
            CoinDrop coinValue = coin.transform.GetChild(0).GetComponent<CoinDrop>();
            int randomCoin = Random.Range(1, 10);

            if (randomCoin == 9)
                coinValue.coin = 17;
            else if (randomCoin == 8 || randomCoin == 7)
                coinValue.coin = 13;
            else
                coinValue.coin = 10;
        }
    }

    //죽었을때 포션 드랍
    public void DropPotion()
    {
        int random = Random.Range(1, 7);
        if (random == 2)
        {
            PotionArray.DropThePotion(gameObject.transform);
        }
    }

    //재활용을 위한 이동 메소드, 애니메이션용 함수
    public void PullingPosition()
    {
        gameObject.GetComponent<NavMeshAgent>().baseOffset = 100f;
    }

    //공격하기
    private void AttackRange()
    {
        if (enemyName == MONSTER_NAME.TRACAN)
            Soundtrack.TracanRoll();
        Collider[] hitColliders = Physics.OverlapBox(transform.position, m_AttackRange / 2);

        if (hitColliders.Length != 0)
        {
            foreach (Collider collider in hitColliders)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    string ex = "";
                    if (enemyName == MONSTER_NAME.TRACAN)
                        ex += MONSTER_NAME.TRACAN.ToString();

                    collider.GetComponent<PlayerMovement>().TakeDamage(ATK, ex);
                }
            }
        }
    }

    //죽었을대 함수
    private void IsDeath()
    {
        if (HP <= 0)
        {
            HP = 1; // 1로 바꾸는 이유는 0이니까 계속 죽는 애니메이션 실행함 그래서 넣음 뺄수 있다면 뺄것
            m_TransTarget = null;

            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.layer = 15;
            ChangeFSM(MONSTER_STATE.Death);
        }
    }

    //오브젝트를 끔 애니메이션용 함수
    private void OffActive()
    {
        gameObject.SetActive(false);
    }

    //행동이 끝났다는걸 알리기용 애니메이션용 함수
    public void IsAttack()
    {
        isAttack = false;
    }
    public void SetDir()
    {
        dir = (transform.position.x <m_TransTarget.position.x) ? 1 : -1;
    }

    public void IsStop()
    {
        isStop = !isStop;
    }

    //시작
    public void Begin()
    {
        m_state.Begin();
    }

    //실행
    public void Run()
    {
        m_state.Run();
    }
    //꺼짐
    public void Exit()
    {
        m_state.Exit();
    }

    //오브젝트가 켜질때마다 실행
    private void OnEnable()
    {
        DEF = Random.Range(1, 3);
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        m_Animator = this.GetComponent<Animator>();
        m_eCurState = MONSTER_STATE.Idle;
        m_ePrevState = MONSTER_STATE.Idle;
        gameObject.layer = 9;
        Init();
    }

    private void Start()
    {
        Begin();
    }

    private void Update()
    {
        Run();
        IsDeath();

        float dir = 0;
        if (m_TransTarget != null) //바라보는 시선 조절
            dir = (transform.position.x < m_TransTarget.position.x) ? 1 : -1;

        if (dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_eCurState != MONSTER_STATE.Death &&
            m_eCurState != MONSTER_STATE.Attack &&
            other.tag == "PlayerArea" && 
            enemyName != MONSTER_NAME.TARRTEA)
        {
            ChangeFSM(MONSTER_STATE.Watch);
        }
        else if(m_eCurState != MONSTER_STATE.Death && m_eCurState != MONSTER_STATE.Attack)
            ChangeFSM(MONSTER_STATE.Attack);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerArea" && enemyName == MONSTER_NAME.BURGY)
        {
            if (m_eCurState != MONSTER_STATE.Death && m_eCurState != MONSTER_STATE.Attack)
                ChangeFSM(MONSTER_STATE.Walk);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(this.gameObject.transform.position, m_FindRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, m_AttackArea);

        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, m_AttackRange);
    }


    public void BurgySound()
    {
        Soundtrack.BurgyAttack();
    }

    public void TarrteaSound()
    {

    }
    public void TracanSound()
    {

    }
}