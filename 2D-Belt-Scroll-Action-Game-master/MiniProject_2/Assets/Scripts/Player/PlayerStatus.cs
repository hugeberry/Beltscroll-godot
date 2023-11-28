using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //스테이터스
    public static int MaxHP = DBStatus.SumHP;
    public static int MaxMP = DBStatus.SumMP;
    public static int ATK = DBStatus.SumAK;
    public static int INT = DBStatus.SumIN;
    public static int DEF = DBStatus.SumDF;

    public readonly static int ANISTS_Idle = Animator.StringToHash("Base Layer.Idle");
    public readonly static int ANISTS_Walk = Animator.StringToHash("Base Layer.Walk");
    public readonly static int ANISTS_Jump = Animator.StringToHash("Base Layer.Jump");
    public readonly static int ANISTS_Fall = Animator.StringToHash("Base Layer.Fall");
    public readonly static int ANISTS_Death = Animator.StringToHash("Base Layer.Death");
    public readonly static int ANISTS_attak1 = Animator.StringToHash("Base Layer.Attack.attak1");
    public readonly static int ANISTS_attak2 = Animator.StringToHash("Base Layer.Attack.attak2");
    public readonly static int ANISTS_attak3 = Animator.StringToHash("Base Layer.Attack.attak3");
    
    public void LoadDBstatus()
    {
        MaxHP = DBStatus.SumHP;
        MaxMP = DBStatus.SumMP;
        ATK = DBStatus.SumAK;
        INT = DBStatus.SumIN;
        DEF = DBStatus.SumDF;
    }
}
