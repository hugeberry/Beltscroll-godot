using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllKill : MonoBehaviour
{
    public static bool AllKillMonster = false;

    private void OnTriggerStay(Collider other)
    {
        if (AllKillMonster)
        {
            Collider[] coll = Physics.OverlapBox(transform.position,GetComponent<BoxCollider>().size);
            foreach(Collider c in coll)
            {
                if (c.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                    c.GetComponent<MonsterFSM>().TakeDamage(1000, false);
            }
        }
    }
}
