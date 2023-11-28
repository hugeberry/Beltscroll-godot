using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 시작시 플레이어가 자동 이동 될 스크립트
public class IntroMove : MonoBehaviour
{

    public Vector3 getAxis = Vector3.zero; //이동 방향
    public float speed = 0;//스피드

    private Animator anim = null; //애니메이션

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalk", true);
        StartCoroutine("StopCoroutine");
        GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        transform.position += getAxis * speed * Time.deltaTime; //이동
    }

    IEnumerator StopCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<Rigidbody>().useGravity = true;
        anim.SetBool("isWalk", false);
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<IntroMove>().enabled = false;
    }
}
