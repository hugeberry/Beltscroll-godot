using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//추상 클래스 스킬.
public abstract class AbstractSkill : MonoBehaviour
{
    public string skillName; // 스킬이름

    protected int skill_INT; //스킬 공격력
    protected Vector3 skillRange; //스킬 범위

    [HideInInspector] public GameObject player; //플레이어 함수를 통해서 초기화
    [HideInInspector] public GameObject skillPoint; //플레이어 함수를 통해서 초기화
    [HideInInspector] public GameObject laserPos; //플레이어 함수를 통해서 초기화

    public void SetSubSkill(int INT, Vector3 range) //스킬 스테이터스 초기화용 함수
    {
        skill_INT = INT + 15; //스킬 보정 데미지 10+
        skillRange = range; //스킬 길이 정함
    }

    public abstract void SkillAttak(); //어택 추상 함수. (매 스키마다 공격 방식이 다를 수 있으니까.)

}
