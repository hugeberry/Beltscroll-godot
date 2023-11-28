using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTarrteaScript : MonoBehaviour
{
    public GameObject hitParticle;
    public GameObject bullet;
    public Transform bulletPosition;
    public float speed = 0.0f;

    private bool isAttack = false;
    private Animator anim;
    private int hitCount = 0;
    private float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitCount >= 5)
        {
            anim.SetBool("isDeath", true);
            Destroy(gameObject, 3.0f);
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0 || v != 0)
        {
            if (h < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (h > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            anim.SetBool("isMove", true);
            transform.Translate(Vector3.right * h * speed * Time.deltaTime);
            transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            isAttack = true;
            anim.SetTrigger("isAttack");
        }
        if (isAttack == true)
        {
            Timer += Time.deltaTime;
        }
        if (Timer >= 1.0f)
        {
            Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
            isAttack = false;
            Timer = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            Debug.Log("Hit!!");
            GameObject temp = Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
            hitCount++;
            anim.SetTrigger("isDamaged");
        }
    }
}
