using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using ITEMS;

namespace ITEMS
{
    public enum ITEM
    {
        WEAPON, SUPWEAPON, ARMOR
    }
}

//상점 아이템 표시 스크립트
public class StoreItem : MonoBehaviour
{
    public ITEM whatItem = ITEM.WEAPON;

    public Image itemImg = null; //아이템 이미지
    public Text itemName = null; //아이템 이름
    public Text price = null; // 가격
    public Text status1 = null; //스텟1
    public Text status2 = null; //스텟2

    public GameObject Sold = null; //스텟2

    private int s_price = 0;
    private GameObject item = null;

    void OnEnable()
    {
        Sold.SetActive(false);
           ItemManager itemStatus = null;
        if (whatItem == ITEM.WEAPON)
        {
            item = WeaponArray.GetWeapon();
            itemStatus = item.GetComponent<WeaponManager>();
            status1.text = item.GetComponent<WeaponManager>().ATK.ToString();
            status2.text = item.GetComponent<WeaponManager>().INT.ToString();
        }
        else if(whatItem == ITEM.SUPWEAPON)
        {
            SubItemStatus sub = GetComponent<SubItemStatus>();
            item = SubWeaponArray.GetSubWeapon();
            itemStatus = item.GetComponent<SubWeapon>();
            SubWeapon sitem = item.GetComponent<SubWeapon>();
            int[] statuss = { sitem.plusHP, sitem.plusMP, sitem.plusATK, sitem.plusINT, sitem.plusDEF };
            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                if(statuss[i] > 0)
                {
                    if(j == 0)
                        status1.text = statuss[i].ToString();
                    else
                        status2.text = statuss[i].ToString();
                    sub.SetIcon(i,j++);
                }
            }
        }
        
        itemImg.sprite = item.GetComponent<Image>().sprite;
        itemName.text = itemStatus.name;
        s_price = Random.Range(itemStatus.minPrice, itemStatus.maxPrice);
        price.text = s_price.ToString();
    }

    public void BuyButton()
    {
        if (HaveCoin.Coin >= s_price)
        {
            if (whatItem == ITEM.WEAPON)
            {
                HaveCoin.Coin -= s_price;
                WeaponArray.BuyItem(item);
            }
            if(whatItem == ITEM.SUPWEAPON)
            {
                HaveCoin.Coin -= s_price;
                SubWeaponArray.BuyItem(item);
            }
            Sold.SetActive(true);
        }
    }
}
