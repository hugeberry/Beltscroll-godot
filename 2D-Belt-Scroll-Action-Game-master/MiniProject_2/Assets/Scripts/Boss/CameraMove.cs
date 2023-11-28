using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public static bool isMove = false;
    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(708, 0, -5), 1.5f * Time.deltaTime);
        }
    }
}
