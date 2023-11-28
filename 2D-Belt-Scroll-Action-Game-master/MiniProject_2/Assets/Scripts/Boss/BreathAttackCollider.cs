using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//브래스 콜라이더 이동 스크립트
public class BreathAttackCollider : MonoBehaviour
{
    public bool onOff = false;
    public bool origin = false;
    // Update is called once per frame
    void Update()
    {
        if (onOff == true)
            AttackCollOn();
        else if(onOff == false)
            AttackCollOff();
    }

    public void AttackCollOn()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(695.2f, -6.9f, -4.9f), 3f * Time.deltaTime);
    }
    public void AttackCollOff()
    {
        if (origin == true)
        {
            transform.position = new Vector3(763.3f, -6.9f, -4.9f);
            origin = false;
        }
    }
}
