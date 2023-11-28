using ArrayPulling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeaponArray : MonoBehaviour
{
    private static ArrayObject<GameObject> SubWeaponArr;

    //무기 배열초기화   오브젝트 풀링
    public static void Initalize()
    {
        SubWeaponArr = new ArrayObject<GameObject>();

        GameObject weaponarr = GameObject.Find("SupWeaponImage");

        for (int i = 0; i < weaponarr.transform.childCount; i++)
        {
            SubWeaponArr.add(weaponarr.transform.GetChild(i).gameObject);
        }
    }

    //
    public static GameObject GetSubWeapon()
    {
        int random = 0;
        GameObject subWeapon = null;
        while (true)
        {
            random = Random.Range(0, SubWeaponArr.length);
            if (SubWeaponArr.get(random).activeSelf == false)
            {
                subWeapon = SubWeaponArr.get(random);
                break;
            }
        }
        return subWeapon;
    }

    public static void BuyItem(GameObject subWeapon)
    {
        for (int i = 0; i < SubWeaponArr.length; i++)
        {
            SubWeaponArr.get(i).SetActive(false);
        }
        SkillName.name = SubWeaponArr.get(subWeapon).GetComponent<AbstractSkill>();
        subWeapon.SetActive(true);
    }

    public static void BuyItem(int subWeapon)
    {
        if (subWeapon != -1)
        {
            for (int i = 0; i < SubWeaponArr.length; i++)
            {
                SubWeaponArr.get(i).SetActive(false);
            }
            SkillName.name = SubWeaponArr.get(subWeapon).GetComponent<AbstractSkill>();
            SubWeaponArr.get(subWeapon).SetActive(true);
        }
        else
        {
            SkillName.name = null;
        }
    }

    public static GameObject NowSubWeapon()
    {
        for (int i = 0; i < SubWeaponArr.length; i++)
        {
            if (SubWeaponArr.get(i).activeSelf)
                return SubWeaponArr.get(i);
        }
        return null;
    }

    public static int SaveDBSubWeapon()
    {
        for (int i = 0; i < SubWeaponArr.length; i++)
        {
            if (SubWeaponArr.get(i).activeSelf)
                return i;
        }
        return -1;
    }
}
