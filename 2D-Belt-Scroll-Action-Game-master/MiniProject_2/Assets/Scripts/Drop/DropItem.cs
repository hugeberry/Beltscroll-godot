using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//드롭아이템 스크립트
public class DropItem : MonoBehaviour
{
    public int throwDamage = 0; //드롭 아이템 대미지
    public bool nuck = false;
    public bool isThrow = false; //던져지고 있는지
    public bool isRotate = false; //돌아갈수 있는지
    public GameObject home; //원래 있던 자리로 갈수있게 받아올 부모 오브젝트 변수

    private void Update()
    {
        if (isRotate)
        {
            transform.parent.Rotate(0,0,-20f); //돌아감
            StartCoroutine("OffCoroutine");//5초 뒤에 꺼짐
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //플레이어에게 닿이면
        {
            other.GetComponent<PlayerMovement>().PickUpDropItem(gameObject); //자신을 플레이어에게 보냄
            other.GetComponent<PlayerMovement>().setIsPickUp(true); //주울 수 있다고 플레이어에게 알림
        }
        if (isThrow) //던져지고 있다면.
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) //적에게 닿이면
            {
                Soundtrack.PlayerDamaged();
                other.GetComponent<MonsterFSM>().TakeDamage(throwDamage, nuck);
                transform.position = Vector3.zero;
                this.transform.parent.gameObject.SetActive(false);
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Boss"))
            {
                Soundtrack.PlayerDamaged();
                other.GetComponent<BossSkill>().TakeDamage(throwDamage);
                transform.position = Vector3.zero;
                this.transform.parent.gameObject.SetActive(false);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().setIsPickUp(false);
        }
    }
    
    IEnumerator OffCoroutine()
    {
        yield return new WaitForSeconds(5f);
        transform.parent.SetParent(home.transform);
        transform.parent.position = Vector3.zero;
        transform.parent.gameObject.SetActive(false);
    }
}