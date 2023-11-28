using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowArmor : MonoBehaviour
{
    public Sprite armor;
    public string name;

    public static Sprite n_armor;
    public static string n_aName;

    private void Start()
    {
        n_armor = armor;
        n_aName = name;
    }

    public static Sprite NowGetArmor()
    {
        return n_armor;
    }

    public static string NowGetArmorName()
    {
        return n_aName;
    }
}
