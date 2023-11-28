using ITEMS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class LoadText : MonoBehaviour
{
    public ITEM item = ITEM.ARMOR;

    private GameObject itemInit;
    private void OnEnable()
    {
        ItemManager itemStatus = null;
        if (item == ITEM.ARMOR)
        {
            GetComponent<Text>().text = NowArmor.n_aName;
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

        GetComponent<Text>().text = itemStatus.name;
    }
}
