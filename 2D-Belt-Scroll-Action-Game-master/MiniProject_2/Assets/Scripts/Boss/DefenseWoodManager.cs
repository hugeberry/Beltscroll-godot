using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//브래스 칸막이 움직임 스크립트
public class DefenseWoodManager : MonoBehaviour
{
    public bool defense = false;
    void Update()
    {
        if (defense == true)
            DefenseOn();
        else
            DefenseOff();
    }

    public void DefenseOn()
    {
        transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = true;
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(new Vector3(0,0, 0)), 3f * Time.deltaTime);
        if (transform.rotation == Quaternion.identity)
        {
            transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void DefenseOff()
    {   
        transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = false;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 70)), 3f * Time.deltaTime);
    }
}
