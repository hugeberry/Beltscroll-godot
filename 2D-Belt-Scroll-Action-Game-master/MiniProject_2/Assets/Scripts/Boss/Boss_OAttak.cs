using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_OAttak : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        StartCoroutine("OffCoroutine");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(25,"");
        }
    }

    IEnumerator OffCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
