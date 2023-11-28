using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class SkillName : MonoBehaviour
{
    public GameObject skill;

    private Text S_name;
    public static AbstractSkill name;

    private void Start()
    {
        S_name = GetComponent<Text>();
    }

    void Update()
    {
        try
        {
            S_name.text = name.skillName;
        }
        catch (Exception e)
        {
            S_name.text = "Nope";
        }
    }
}
