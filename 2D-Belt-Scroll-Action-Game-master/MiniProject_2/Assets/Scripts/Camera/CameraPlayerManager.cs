using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카메라 안에 가두기 위한 스크립트
public class CameraPlayerManager : MonoBehaviour
{
    void Update()
    {
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0.05f) worldpos.x = 0.05f; //최대,최소 값이 0~1임
        if (worldpos.x > 0.95f) worldpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }
}
