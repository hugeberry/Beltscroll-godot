using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersArea : MonoBehaviour
{
    public int howManyDie = 0;
    public static int HowMany = 0;

    private void Start()
    {
        HowMany = howManyDie;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}