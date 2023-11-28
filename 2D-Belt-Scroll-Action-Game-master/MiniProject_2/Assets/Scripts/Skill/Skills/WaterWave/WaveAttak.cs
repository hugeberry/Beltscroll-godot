using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttak : MonoBehaviour
{
    public static int waveDamage = 0;

    private void OnEnable()
    {
        Soundtrack.Wave();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<MonsterFSM>().TakeDamage(waveDamage, true);
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Boss"))
            other.GetComponent<BossSkill>().TakeDamage(waveDamage);
    }
}
