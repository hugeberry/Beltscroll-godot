using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBulletScript : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject bulletHitParticle;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject temp = Instantiate(bulletHitParticle, transform.position, transform.rotation);
            Destroy(temp, 2.0f);
            Destroy(gameObject);
        }
    }
}
