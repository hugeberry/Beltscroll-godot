using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//총알 스크립트
public class BulletScript : MonoBehaviour
{
    public float speed = 1.0f; //날아가는 속도

    public int Attack; //데미지

    private void OnEnable()
    {
        StartCoroutine("OffCoroutine"); //코르틴 시작!ㄴ
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); //날라간다이
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Soundtrack.bulletSoundSimple();
            other.GetComponent<PlayerMovement>().TakeDamage(Attack, "explosion");
            transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    IEnumerator OffCoroutine()//5초뒤에 자동으로 꺼줌
    {
        yield return new WaitForSeconds(5f);
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }
}
