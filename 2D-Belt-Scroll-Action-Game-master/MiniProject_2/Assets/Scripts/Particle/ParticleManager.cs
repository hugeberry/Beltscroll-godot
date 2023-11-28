using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//파티클 시스템에 들어갈 스크립트
public class ParticleManager : MonoBehaviour
{
    public void OnEnable()
    {
        StartCoroutine("EndCoroutine");
    }    

    IEnumerator EndCoroutine()//1.5초뒤 자동으로 꺼짐
    {
        yield return new WaitForSeconds(1f);
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }
}
