using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColl : MonoBehaviour
{

    private void OnEnable()
    {
        Soundtrack.MeteorEx();
        gameObject.GetComponent<ParticleSystem>().Play();
        StartCoroutine("OffCoroutine");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<MonsterFSM>().TakeDamage(60,false);
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            other.GetComponent<BossSkill>().TakeDamage(40);
        }
    }

    IEnumerator OffCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider>().enabled = true;
        transform.parent.gameObject.SetActive(false);
    }
}
