using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Enemy")
        {
            other.GetComponent<IsSafe>().isSafe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            other.GetComponent<IsSafe>().isSafe = false;
        }
    }
}
