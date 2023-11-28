using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArray : MonoBehaviour
{
    private static ArrayObject<GameObject> WeaponArr;

    //무기 배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        WeaponArr = new ArrayObject<GameObject>();

        GameObject weaponarr = GameObject.FindWithTag("L_hand_Weapon");

        for (int i = 0; i < weaponarr.transform.childCount; i++)
        {
            WeaponArr.add(weaponarr.transform.GetChild(i).gameObject);
        }
    }

    //
    public static GameObject GetWeapon()
    {
        int random = 0;
        GameObject weapon = null;
        while (true)
        {
            random = Random.Range(1, WeaponArr.length);
            if (WeaponArr.get(random).activeSelf == false)
            {
                weapon = WeaponArr.get(random);
                break;
            }
        }
        return weapon;
    }

    public static void BuyItem(GameObject weapon)
    {
        for (int i = 0; i < WeaponArr.length; i++)
        {
            WeaponArr.get(i).SetActive(false);
        }

        weapon.SetActive(true);
    }

    public static void BuyItem(int weapon)
    {
        for (int i = 0; i < WeaponArr.length; i++)
        {
            WeaponArr.get(i).SetActive(false);
        }

        WeaponArr.get(weapon).SetActive(true);
    }

    public static GameObject NowWeapon()
    {
        for (int i = 0; i < WeaponArr.length; i++)
        {
            if (WeaponArr.get(i).activeSelf)
                return WeaponArr.get(i);
        }
        return null;
    }

    public static int SaveDBWeapon()
    {
        for (int i = 0; i < WeaponArr.length; i++)
        {
            if (WeaponArr.get(i).activeSelf)
                return i;
        }
        return -1;
    }
}
