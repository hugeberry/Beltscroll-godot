using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : PlayerStatus
{
    //프로그램용 스테이터스
    [HideInInspector]public int currentMaxHP = 0;
    private int currentMaxMP = 0;
    private int currentHP = 0;
    private int currentMP = 0;
    private int currentATK = 0;
    private int currentINT = 0;
    private int currentDEF = 0;

    //기타 스테이터스.
    public Slider hpBar; //체력통
    public Slider backHpBar; //배경 체력통
    public Slider mpBar; //마나통
    public Slider backMpBar; //배경 마나통
    public Animator hpbarAnim; //체력 애니메이션
    public float speed = 1.0f; //이동속도
    public float jumpPower = 1.0f; //점프 높이

    public AnimationClip death = null;

    //기능 변수들
    private bool isGround = false; //땅에 붙어있는지 확인용
    private bool isAttack = false; //행동중인지 확인용
    private bool isPickUp = false; //아이템을 주웠는지 확인용
    private bool isDropItem = false; //아이템을 던질수 있는지 확인용
    private bool isbackHpHit = false; //체력통이 자련스럽게 줄어들때 필요한 변수
    private bool isbackMpHit = false; //마나통이 자련스럽게 줄어들때 필요한 변수
    private bool isSubWeapon = false; //보조무기가 있는지 확인용

    //이동용
    private Vector3 dir;

    //오브젝트 변수들
    private Animator anim;
    private Shadow shadow;
    private Rigidbody rigid;
    private DropItem dropItem;
    private WeaponManager weapon;
    private SubWeapon subWeapon;
    GameObject r_hand;

    //애니 관련 변수
    volatile bool atkInputEnabled = false;
    volatile bool atkInputNow = false;

    public Text textHP;
    public Text textMP;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        shadow = FindObjectOfType(typeof(Shadow)) as Shadow;
        r_hand = GameObject.FindWithTag("R_hand_Weapon");
        dir = Vector3.zero;
        LoadDBstatus();
        DBStatus.LoadWeapon();
        DBStatus.LoadSebWeapon();
        DBStatus.LoadArmor();
    }
    private void OnEnable() //켜질때마다 무기, 보조무기 있는지 확인 후 스텟 초기화
    {
        GetSubWeapon();
        CameraPrison.Boss = false;
        GetWeapons();
        ResetStatus();
        IsAttack();
        weapon.setAtk(currentATK); //무기에 공격력 넣음
        gameObject.layer = 10;
        StopCoroutine("SelfHealMPCoroutine");
        StartCoroutine("SelfHealMPCoroutine");
    }

    void FixedUpdate()
    {
        //지워야됨
        textHP.text = currentHP.ToString() + " / " + currentMaxHP.ToString();
        textMP.text = currentMP.ToString() + " / " + currentMaxMP.ToString();
        //지워야됨
        Death(); //쥬금

        Attack(); //공격
        Jump(); //점프
        GetDropItem(); //아이템 줍고 던지는거

        Move(); //움직일때 

        hpBar.value = Mathf.Lerp(hpBar.value, currentHP, 0.5f); // 체력 자연스럽게 내려가기
        if (isbackHpHit)//뒤따라오는 체력 게이지
        {
            backHpBar.value = Mathf.Lerp(backHpBar.value, hpBar.value, Time.deltaTime * 10f);
            if (hpBar.value >= backHpBar.value - 0.01f)
            {
                isbackHpHit = false;
                backHpBar.value = hpBar.value;
            }
        }

        mpBar.value = Mathf.Lerp(mpBar.value, currentMP, 0.5f); // 마나 자연스럽게 내려가기
        if (isbackMpHit)//뒤따라오는 마나 게이지
        {
            backMpBar.value = Mathf.Lerp(backMpBar.value, mpBar.value, Time.deltaTime * 10f);
            if (mpBar.value >= backMpBar.value - 0.01f)
            {
                isbackMpHit = false;
                backMpBar.value = mpBar.value;
            }
        }
    }

    //움직임 메소드
    public void Move()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        /**dir * speed * Time.deltaTime;*/

        if (dirX == 0 && dirY == 0 )
        {
            anim.SetBool("isWalk", false);
        }
        else if(dirX != 0 || dirY != 0)
        {
            if(isAttack == false)
            {
                transform.position += new Vector3(dirX * speed * Time.deltaTime, 0, dirY * speed * Time.deltaTime);
                Direction();
                anim.SetBool("isWalk", true);
            }
        }
    }

    //이동 방향에따라 캐릭터 방향도 바뀜
    public void Direction()
    {
        Vector3 moveVector;

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = 0.0f;
        moveVector.z = Input.GetAxisRaw("Vertical");

        dir = moveVector;

        if (dir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //점프 메소드
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isAttack && isGround)
        {
            Soundtrack.Jump();
            isGround = false;
            anim.SetTrigger("isFall");
            anim.SetBool("isJump", true);
            rigid.AddForce(Vector3.up * jumpPower);
        }
    }

    //현재 실행중인지를 확인하는 함수  애니메이션용 함수
    public void EnebleAttackInput()
    {
        atkInputEnabled = true;//바꿀수 있게 true로 만듬
    }

    //애니메이션 변경용 함수 애니메이션용 함수
    public void SetNextAttack(string name)
    {
        if(atkInputNow == true) //현재 바꿀수 있는 상태라면
        {
            atkInputNow = false; //바꿀수없게 false 로 해주고
            anim.Play(name); //바꿀 애니메이션 실행
        }
    }

    //콤보에 의한 +데미지 애니메이션용 함수
    public void ComboPlusDamage(int damage)
    {
        weapon.comboPlusDamage = damage;
    }

    //공격 메소드
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0); //애니메이터의 정보를 가져옴

            if (!isGround)
            {
                isAttack = true;
                anim.SetTrigger("PossibleJumpAttack");
            }
            else if (isGround && stateInfo.nameHash == ANISTS_Idle ||
                    stateInfo.nameHash == ANISTS_Walk ||
                    stateInfo.nameHash == ANISTS_attak1) { //현재 진행중인 애니메이션이 기본, 걷기, 점프, 어택1 이면 공격함.
                isAttack = true;
                anim.SetTrigger("isAttack");
            }
            else
            {
                if (atkInputEnabled) //현재 실행중이라면
                {
                    atkInputEnabled = false; //다시 실행 안되게 false로 바꿈
                    atkInputNow = true; //행동을 바꿀 수 있다고 true로 바꿈
                }
            }
        }

        // 보조무기가 있고 행동중이 아니며 마나가 20 이상이다! 그럼 A를 누르면 실행
        if (isSubWeapon && !isAttack && currentMP >= 20 && Input.GetKeyDown(KeyCode.A)) //스킬 사용 서브 아이템이 있을때 실행함
        {
            currentMP -= 20;
            Invoke("BackMpHit", 0.3f);

            isAttack = true;
            anim.Play("Skill");
        }
    }
    //행동 변경용 스크립트 애니메이션용 함수
    public void IsAttack(){ isAttack = false; }

    //공격용 애니메이션용 함수
    public void WeaponAttack()
    {
        weapon.Attack();
    }
    //스킬 공격 함수 애니메이션용 함수
    public void SkillAttack()
    {
        subWeapon.SetSkillDamage(currentINT + weapon.INT);
    }


    //줍기, 던지기 입력 관리 메소드
    public void GetDropItem()
    {
        if (Input.GetKeyDown(KeyCode.C) && isGround)
        {

            if (isDropItem)
            {
                isAttack = true;
                anim.Play("Throw");
            }
            else if (isPickUp)
            {
                isAttack = true;
                anim.Play("Get");
            }
        }
    }

    //데미지를 받음
    public void TakeDamage(int damage, string ex)
    {
        isAttack = true;
        int takeDamage = DamageMathf(damage, ex);
        currentHP -= (takeDamage);
        CreateDamageText.CreateText(takeDamage.ToString(), ex, transform);

        Soundtrack.PlayerDamaged();

        hpbarAnim.SetTrigger("HitDamage");
        anim.Play("Damaged1");

        Invoke("BackHpHit", 0.3f);
    }

    private int DamageMathf(int damage, string ex)
    {
        int takeDamage = damage;
        if (ex != MONSTER_NAME.TRACAN.ToString())
        {
            if (damage > currentDEF)
                takeDamage -= currentDEF;
            else
                takeDamage = 1;
        }
        return takeDamage;
    }

    public void TakeHeal(int heal) //물약 먹었을때
    {
        Soundtrack.Heal();

        if (currentHP + heal > currentMaxHP)
            currentHP = currentMaxHP;
        else
            currentHP += heal;
        CreateHealText.CreateText(heal, transform);
        BackHpHit();
    }

    public bool CanHeal() { return !(currentHP >= currentMaxHP); }

    public void BackHpHit() { isbackHpHit = true; } //뒷 배경 체력바 줄이기용
    public void BackMpHit() { isbackMpHit = true; } //뒷 배경 마나바 줄이기용

    //가지고있는 무기 가져옴
    public void GetWeapons()
    {
        weapon = FindObjectOfType(typeof(WeaponManager)) as WeaponManager;
    }
    // 서브무기를 가져옴
    public void GetSubWeapon()
    {
        subWeapon = FindObjectOfType(typeof(SubWeapon)) as SubWeapon;
        if (subWeapon != null)
            isSubWeapon = true;
        else
            isSubWeapon = false;
    }

    public void setIsDrowItem(bool have){ isDropItem = have; } //드롭 아이템을 가지고 있다면 true

    public void setIsPickUp(bool isPick) { isPickUp = isPick; } //드롭 아이템을 주울 수 있는지

    public void PickUpDropItem(GameObject sub){ dropItem = sub.GetComponent<DropItem>(); }//주웠다면 해당 아이템의 스크립트를 가져옴

    //기능용 스텟 초기화 메소드
    public void ResetStatus()
    {
        //보조장비가 있을경우 스텟 초기화 메소드
        if (isSubWeapon)
        {
            currentMaxHP = MaxHP + subWeapon.plusHP;
            currentMaxMP = MaxMP + subWeapon.plusMP;
            currentATK = ATK + subWeapon.plusATK;
            currentINT = INT + subWeapon.plusINT;
            currentDEF = DEF + subWeapon.plusDEF;
        }
        else
        {
            currentMaxHP = MaxHP;
            currentMaxMP = MaxMP;
            currentATK = ATK;
            currentINT = INT;
            currentDEF = DEF;
        }

        currentHP = currentMaxHP;
        currentMP = currentMaxMP;

        hpBar.maxValue = currentMaxHP;
        hpBar.value = currentMaxHP;
        mpBar.maxValue = currentMaxMP;
        mpBar.value = currentMaxMP;

        backHpBar.maxValue = currentMaxHP;
        backHpBar.value = currentMaxHP;
        backMpBar.maxValue = currentMaxMP;
        backMpBar.value = currentMaxMP;

    }

    public void GetArmorDEF(int armor, int hp, int mp)
    {
        MaxHP = MaxHP + hp;
        currentHP = currentHP + hp;
        MaxMP = MaxMP + mp;
        currentMP = currentMP + mp;
        DEF = DEF + armor;
    }
    public void ChangeArmorDEF(int armor, int hp, int mp)
    {
        MaxHP -= hp;
        currentHP -= hp;
        MaxMP -= mp;
        currentMP -= mp;
        DEF -= armor;
    }

    //아이템을 줍는다. 애니메이션용 함수
    public void PickUpItem()
    {
        Soundtrack.DropItemSound();
        isDropItem = true;
        Transform c_dropItem = dropItem.transform.parent;
        Rigidbody dropRigid = c_dropItem.GetComponent<Rigidbody>();
        dropRigid.isKinematic = true; // 고정시킴
        dropRigid.useGravity = false; //중력 해제

        c_dropItem.SetParent(r_hand.transform); //부모 설정
        c_dropItem.localPosition = Vector3.zero;//위치 0으로 초기화.
    }

    //드롭 아이템을 던지다.  애니메이션용 함수
    public void ThrowDropItem()
    {
        Soundtrack.ThrowItemSound();
        Vector3 scale = transform.right;
        GameObject throwitem = dropItem.transform.parent.gameObject;
        Rigidbody itemRigid = throwitem.GetComponent<Rigidbody>();
        float dirX = 2.5f;

        if (transform.localScale.x == -1)
        {
            scale = -scale;
            dirX = -dirX;
        }
        isDropItem = false;  //던질수 있는 아이템이 없다.
        isPickUp = false;    //들고있는 아이템이 없다.
        dropItem.isThrow = true;  //해당 아이템이 던져지고 있다고 표시할 변수
        dropItem.isRotate = true; //해당 아이템이 빙빙 돌아갈 수 있도록 하는 변수

        throwitem.transform.parent = null; // 부모를 뺴버림
        throwitem.transform.position = new Vector3(transform.position.x + dirX, transform.position.y + 1.7f, transform.position.z); //위치값 설정
        itemRigid.isKinematic = false; //고정위치 해제
        itemRigid.AddForce(scale * 5000); // 던져지는 파워
    }

    //사망
    public void Death()
    {
        if (currentHP <= 0)
        {
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

            gameObject.layer = 15;
            isAttack = true;
            anim.Play("Death");
            if (stateInfo.nameHash == ANISTS_Death && stateInfo.normalizedTime >= 0.9f)
            {
                Time.timeScale = 0;
                transform.localScale = new Vector3(1, 1, 1);
                gameObject.SetActive(false);
                GameObject.Find("CanvasUI").transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    IEnumerator SelfHealMPCoroutine()
    {
        yield return new WaitForSeconds(3f);
        if(currentMP < currentMaxMP)
            currentMP += 2;
        if (currentMP > currentMaxMP)
            currentMP = currentMaxMP;

        StartCoroutine("SelfHealMPCoroutine");
    }

    public bool IsGround() { return isGround; }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Soundtrack.Land();
            shadow.isGround = true;
            isGround = true;
            anim.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            shadow.isGround = false;
            isGround = false;
        }
    }
}