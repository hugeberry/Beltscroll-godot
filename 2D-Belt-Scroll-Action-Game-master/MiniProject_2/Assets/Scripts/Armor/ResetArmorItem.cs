using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetArmorItem : ArmorManager
{
    private void OnEnable()
    {
        SetRandomArmor();
        sold.SetActive(false);
    }
}
