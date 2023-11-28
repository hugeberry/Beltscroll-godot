using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//코인 스크립트
public class CoinDrop : MonoBehaviour
{
    public int coin;

    private float speed; //날라갈 속도
    private float power; //회전할 파워

    private Rigidbody r; 

    private void Awake()
    {
        r = transform.parent.GetComponent<Rigidbody>();
        r.maxAngularVelocity = 255;
        speed = 2100;
        power = 255f;
    }

    private void OnEnable()
    {
        transform.position = transform.parent.position;
        float randomX = Random.Range(-0.5f,0.5f);

        r.AddForce(new Vector3(randomX, 2, 0) * speed);
        r.AddTorque(new Vector3(0f, 0f, 1) * power);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Soundtrack.Coin();
            CreateCoinText.CreateText(coin, transform);
            HaveCoin.Coin += coin;
            transform.position = Vector3.zero;
            transform.parent.gameObject.SetActive(false);
        }
    }

}