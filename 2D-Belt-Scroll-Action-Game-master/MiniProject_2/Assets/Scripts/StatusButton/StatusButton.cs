using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatusButton : MonoBehaviour
{
    public Image slider = null;

    private PlayerStatus p_Status = null;

    private int HP = 0;
    private int MP = 0;
    private int ATK = 0;
    private int INT = 0;
    private int DEF = 0;

    private int multiplicationHP = 0;
    private int multiplicationATK = 0;
    private int multiplicationINT = 0;
    private int multiplicationDEF = 0;

    public static int DDHP = 0;

    private void Awake()
    {
        HP = PlayerStatus.MaxHP;
        MP = PlayerStatus.MaxMP;
        ATK = PlayerStatus.ATK;
        INT = PlayerStatus.INT;
        DEF = PlayerStatus.DEF;
    }

    void Start()
    {
        string name = slider.transform.parent.parent.gameObject.name;
        if (name == "SliderHP")
        {
            multiplicationHP = (int)((PlayerTotalData.MHP - 150) * 0.1f);
            slider.fillAmount = multiplicationHP * 0.1f;
        }
        else if (name == "SliderINT")
        {
            multiplicationINT = (int)((PlayerTotalData.MMP - 100) * 0.1f);
            slider.fillAmount = multiplicationINT * 0.1f;
        }
        else if (name == "SliderATK")
        {
            multiplicationATK = (int)((PlayerTotalData.AK - 7) / 3);
            slider.fillAmount = multiplicationATK * 0.1f;
        }
        else if (name == "SliderDEF")
        {
            multiplicationDEF = (int)((PlayerTotalData.DF));
            slider.fillAmount = multiplicationDEF * 0.1f;
        }
    }

    public void PlusStatusHP()
    {
        if (StatusCount.statucCount != 0 && multiplicationHP != 10)
        {
            StatusCount.statucCount--;
            slider.fillAmount += 0.1f;
            PlayerStatus.MaxHP = HP + (10 * ++multiplicationHP);
        }
        PlayerTotalData.HealthPoint = PlayerStatus.MaxHP-150;

    }
    public void PlusStatusATK()
    {
        if (StatusCount.statucCount != 0 && multiplicationATK != 10)
        {
            StatusCount.statucCount--;
            slider.fillAmount += 0.1f;
            PlayerStatus.ATK = ATK + (2 * ++multiplicationATK);
        }
        PlayerTotalData.AttackPoint = PlayerStatus.ATK-7;
    }
    public void PlusStatusINT()
    {
        if (StatusCount.statucCount != 0 && multiplicationINT != 10)
        {
            StatusCount.statucCount--;
            slider.fillAmount += 0.1f;
            PlayerStatus.MaxMP = MP + (10 * ++multiplicationINT);
            PlayerStatus.INT = INT + (3 * multiplicationINT);
        }
        PlayerTotalData.ManaPoint = PlayerStatus.MaxMP - 100;
        Debug.Log(PlayerTotalData.ManaPoint);
        PlayerTotalData.IntegerPoint = PlayerStatus.INT - 5;
    }
    public void PlusStatusDEF()
    {
        if (StatusCount.statucCount != 0 && multiplicationDEF != 10)
        {
            StatusCount.statucCount--;
            slider.fillAmount += 0.1f;
            PlayerStatus.DEF = DEF + (1 * ++multiplicationDEF);
        }
        PlayerTotalData.DfancePoint = PlayerStatus.DEF;
    }

    public void sliderPlus()
    {
        slider.fillAmount += 0.1f;
    }

    /*public void  */
}
