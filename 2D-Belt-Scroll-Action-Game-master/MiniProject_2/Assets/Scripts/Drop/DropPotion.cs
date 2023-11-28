using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPotion : MonoBehaviour
{
    public int heal = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (other.GetComponent<PlayerMovement>().CanHeal())
            {
                other.GetComponent<PlayerMovement>().TakeHeal(heal);
                transform.position = Vector3.zero;
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
