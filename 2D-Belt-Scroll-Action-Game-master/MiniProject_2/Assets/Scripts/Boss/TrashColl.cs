using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashColl : MonoBehaviour
{
    public GameObject ex;

    private void OnEnable()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10, -35), 60, Random.Range(-5, 7));
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ex.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
