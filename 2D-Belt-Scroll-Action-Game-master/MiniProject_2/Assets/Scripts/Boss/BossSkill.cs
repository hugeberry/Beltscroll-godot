using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossSkill : Boss
{
    public Vector3 meleeRange; //근접 공격 범위
    public Vector3 AttractRanged; //근접 공격 범위
    public ParticleSystem particle;

    public float a_Power; //당기는 힘
    public GameObject[] defenseWood; //브래스 막이
    public GameObject breathAttackColl; // 브레스 공격 범위
    public Slider slider = null;
    public GameObject SponeEnemy;

    private int num = 0;
    private int num1 = 0;
    private int maxran = 1;
    private int maxran1 = 1;
    private int currentHP;
    private Transform playerTr; //플레이어
    private Animator anim;
    private bool isAction;
    private ResponPoint spone = null;
    public GameObject dropPosition; //오브젝트 풀링하면 사라질 변수, 폭탄 소환용
    //private BoxCollider boxColl;
    void OnEnable()
    {
        maxran = 1;
        maxran1 = 1;
        playerTr = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
        isAction = false;
        StartCoroutine("BossAction");
        slider.maxValue = b_HP;
        slider.value = b_HP;
        currentHP = b_HP;
        spone = GetComponent<ResponPoint>();
    }

    private void Update()
    {
        slider.value = Mathf.Lerp(slider.value, currentHP, 2f * Time.deltaTime);
        IsDeath();
    }


    public void IsAction()
    {
        isAction = false;
        StartCoroutine("BossAction");
    }

    IEnumerator BossAction()
    {
        yield return new WaitForSeconds(2f);
        if (!isAction)
        {
            isAction = true;
            float dist = Vector2.Distance(this.transform.position, playerTr.position);
            num = Random.Range(0, maxran);
            num1 = Random.Range(0, maxran1);

            if (num1 == 0 && currentHP <= (b_HP * 0.7))
            {
                IsAction();
                Soundtrack.B_Damage(); Soundtrack.B_Damage(); Soundtrack.B_Damage();
                SponeEnemy.SetActive(true);
                SponeEnemy.SetActive(false);
                maxran1 = 8;
            }
            else if (num == 0 && currentHP <= (b_HP * 0.5))
            {
                anim.SetBool("isBreath", true);
                maxran = 5;
            }
            else if (dist <= 12f)
            {
                int ranAtk = Random.Range(0, 2);
                if (ranAtk == 0)
                {
                    anim.SetTrigger("isLight");
                }
                else
                {
                    anim.SetTrigger("isHeavy");
                }
            }
            else
            {
                int random = Random.Range(0, 5);
                if(random == 0)
                    anim.SetTrigger("isSummon");
                else
                    anim.SetTrigger("isDrop");
            }
        }
    }

    public void MeleeAttack(int ATK)
    {
        Collider[] coll = Physics.OverlapBox(transform.position, meleeRange);
        Soundtrack.B_Attack();
        foreach (Collider collider in coll)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                collider.GetComponent<PlayerMovement>().TakeDamage(ATK, "");
            }
            else if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                collider.GetComponent<MonsterFSM>().TakeDamage(ATK, false);
            }
        }
    }

    public void ComboAttak()
    {
        int ran = Random.Range(0,3);
        if (ran == 0)
            anim.Play("HeavyAttack");
    }

    public void BreathOn()
    {
        Soundtrack.B_Brearth();
        breathAttackColl.GetComponent<BreathAttackCollider>().onOff = true;
    }

    public void BreatOff()
    {
        breathAttackColl.GetComponent<BreathAttackCollider>().onOff = false;
        breathAttackColl.GetComponent<BreathAttackCollider>().origin = true;
        anim.SetBool("isBreath", false);
        DefenderOff();
    }

    public void DefenderOn()
    {
        for (int i = 0; i < 2; i++)
        {
            while (true)
            {
                int ran = Random.Range(0, 4);
                DefenseWoodManager def = defenseWood[ran].GetComponent<DefenseWoodManager>();
                if (def.defense != true)
                {
                    def.defense = true;
                    break;
                }
            }
        }
    }

    public void DefenderOff()
    {
        for (int i = 0; i < defenseWood.Length; i++)
        {
            defenseWood[i].GetComponent<DefenseWoodManager>().defense = false;
        }
    }

    public void SummoneMonster()
    {
        Soundtrack.B_Summon();
        int ran = Random.Range(0,3);
        switch (ran)
        {
            case 0:
                spone.b_many = 1;
                spone.sponed();
                spone.b_many = 0;
                break;
            case 1:
                spone.tt_many = 1;
                spone.sponed();
                spone.tt_many = 0;
                break;
            case 2:
                spone.t_many = 1;
                spone.sponed();
                spone.t_many = 0;
                break;
        }
    }

    public IEnumerator AttractCoroutine(float t)
    {
        Soundtrack.B_Charge();
        float time = 0;
        while (time < t)
        {
            Collider[] coll = Physics.OverlapBox(transform.position, AttractRanged / 2);
            foreach (Collider collider in coll)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    collider.GetComponent<Rigidbody>().AddForce(Vector3.right * a_Power);
                }
                else if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    collider.GetComponent<Rigidbody>().AddForce(Vector3.right * (a_Power * 1.5f));
                }
            }
            time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator LongDistanceAttackCoroutine()
    {
        for (int i = 0; i < 6; i++)
        {
            Soundtrack.B_TrashDrop();
            BossPoArray.TrashSpone(dropPosition.transform.position);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void TakeDamage(int damage)
    {
        Soundtrack.B_Damage();
        CreateDamageText.CreateText(damage.ToString(), "" , transform);
        currentHP -= damage;
    }

    public void IsDeath()
    {
        if (currentHP <= 0)
        {
            StopAllCoroutines();
            DefenderOff();
            anim.Play("Death");
            gameObject.layer = 15;
            AllKill.AllKillMonster = true;
        }
    }

    public void BossDeathSound()
    {
        Soundtrack.B_Death();
    }

    public void Ending()
    {
        DestroyObject(GameObject.Find("MainScene"));
        SceneManager.LoadScene("EX");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, meleeRange);
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, AttractRanged);
    }
}
