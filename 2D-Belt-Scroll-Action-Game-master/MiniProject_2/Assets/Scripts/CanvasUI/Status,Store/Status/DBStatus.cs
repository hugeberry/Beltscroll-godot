using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBStatus : MonoBehaviour
{
    private static int MaxHPs = 0;
    private static int MaxMPs = 0;
    private static int ATKs = 0;
    private static int INTs = 0;
    private static int DEFs = 0;

    private static int UPHPs = 0;
    private static int UPMPs = 0;
    private static int UPAKs = 0;
    private static int UPINs = 0;
    private static int UPDFs = 0;

    public static int SumHP = MaxHPs + UPHPs;
    public static int SumMP = MaxMPs + UPMPs;
    public static int SumAK = ATKs + UPAKs;
    public static int SumIN = INTs + UPINs;
    public static int SumDF = DEFs + UPDFs;

    public static int SumCO;

    public static void ReData()
    {
        MaxHPs = PlayerTotalData.MHP;
        MaxMPs = PlayerTotalData.MMP;
        ATKs = PlayerTotalData.AK;
        INTs = PlayerTotalData.IN;
        DEFs = PlayerTotalData.DF;

        UPHPs = PlayerTotalData.HealthPoint;
        UPMPs = PlayerTotalData.ManaPoint;
        UPAKs = PlayerTotalData.AttackPoint;
        UPINs = PlayerTotalData.IntegerPoint;
        UPDFs = PlayerTotalData.DfancePoint;

        SumHP = MaxHPs + UPHPs;
        SumMP = MaxMPs + UPMPs;
        SumAK = ATKs + UPAKs;
        SumIN = INTs + UPINs;
        SumDF = DEFs + UPDFs;
        HaveCoin.Coin = SumCO;
    }

    public static void LoadWeapon()
    {
        WeaponArray.BuyItem(PlayerTotalData.DMain);
    }

    public static void LoadSebWeapon()
    {
        SubWeaponArray.BuyItem(PlayerTotalData.DSub);
    }

    public static void LoadArmor()
    {
        ArmorManager.DBLoadArmor(PlayerTotalData.DArmor);
    }
}
