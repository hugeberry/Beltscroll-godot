using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using ITEMS;
using System;

public class LoadItem : MonoBehaviour
{
    public ITEM item = ITEM.ARMOR;

    private GameObject itemInit;
    private void OnEnable()
    {
        ItemManager itemStatus = null;
        if (item == ITEM.ARMOR)
        {
            GetComponent<Image>().sprite = NowArmor.NowGetArmor();
            return;
        }
        else if (item == ITEM.WEAPON)
        {
            itemInit = WeaponArray.NowWeapon();
            itemStatus = itemInit.GetComponent<WeaponManager>();
        }
        else
        {
            try
            {
                itemInit = SubWeaponArray.NowSubWeapon();
                itemStatus = itemInit.GetComponent<SubWeapon>();
            }
            catch (Exception e)
            {
                return;
            }

        }

        GetComponent<Image>().sprite = itemInit.GetComponent<Image>().sprite;
    }
}
