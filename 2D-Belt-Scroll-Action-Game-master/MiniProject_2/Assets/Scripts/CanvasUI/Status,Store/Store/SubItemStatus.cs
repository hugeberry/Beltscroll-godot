using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SubItemStatus : MonoBehaviour
{
    public Sprite[] icon;
    public Image[] statusIcon;

    public void SetIcon(int i,int j)
    {
        statusIcon[j].sprite = icon[i];
    }

}   