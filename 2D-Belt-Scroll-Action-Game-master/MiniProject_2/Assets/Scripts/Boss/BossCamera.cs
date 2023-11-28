using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{

    private static GameObject CM_Camera = null;
    public static GameObject target = null;
    public static float cameraSize = 0;

    void Start()
    {
        CM_Camera = GameObject.Find("CM vcam1");
    }

    public static void CameraChange(GameObject target)
    {
        CM_Camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = target.transform;
    }

    public static void CameraZomeOut(float cameraSize)
    {
        CM_Camera.GetComponent<Cinemachine.CinemachineVirtualCamera>().m_Lens.OrthographicSize = cameraSize;
    }
}
