using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoCollider : MonoBehaviour
{
    public GameObject ex;

    private void OnEnable()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.right * 10000);
        ex.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            ex.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
