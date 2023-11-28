using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSet : MonoBehaviour
{
    public List<Sprite[]> Armor = new List<Sprite[]>();
    public Sprite[] DiverArmor;
    public Sprite[] TropicalArmor;
    private void Awake()
    {
        Armor.Add(DiverArmor);
        Armor.Add(TropicalArmor);
    }
}
