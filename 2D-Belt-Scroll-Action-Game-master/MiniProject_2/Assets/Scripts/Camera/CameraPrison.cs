using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카메라를 가두게 할 스크립트. 이걸 통해서 벨트스크롤 느낌 낼거임 야메임 이방식은
public class CameraPrison : MonoBehaviour
{
    public CameraPlayerManager player;
    public GameObject Camera;
    public static bool prison = false;
    public static bool Boss = false;
    public static int dieCount = 0;

    // Update is called once per frame
    void Update()
    {

        if (prison && dieCount >= MonstersArea.HowMany && Boss != true)
        {
            prison = false;
        }


        if (prison)
            Prison();
        else
            UnPrison();

    }

    public void Prison()
    {
        player.enabled = true;
        transform.parent = null;
    }

    public void UnPrison()
    {
        player.enabled = false;
        transform.parent = Camera.transform;
         transform.position = Vector3.Lerp(transform.position, Camera.transform.position, Time.deltaTime);
    }
}
