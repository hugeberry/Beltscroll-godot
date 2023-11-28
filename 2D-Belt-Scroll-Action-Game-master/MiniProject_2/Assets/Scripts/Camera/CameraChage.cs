using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChage : MonoBehaviour
{
    public GameObject target = null;
    public float cameraMaxSize = 0;
    public float cameraMinSize = 0;
    public GameObject canvas = null;
    public GameObject boss = null;
    public GameObject stage3 = null;
    public AudioClip BossBGM = null;
    public AudioClip stage3BGM = null;
    public AnimationClip bossDeath = null;
    public GameObject breathShow = null;
    public GameObject charge = null;

    public static bool restart = false;
    public static bool setBossPlayerRespone = false;

    public GameObject bossSpone = null;

    private float currentSize = 0;
    private bool setMove = false;

    private void Update()
    {
        if (setMove)
        {
            currentSize = Mathf.Lerp(currentSize, cameraMaxSize, 2 * Time.deltaTime);
            BossCamera.CameraZomeOut(currentSize);
            bossDeath.SampleAnimation(boss, 0);
            CameraPrison.Boss = true;
            if (currentSize >= cameraMaxSize - 0.01f)
            {
                setMove = false;
                CameraMove.isMove = false;
                CameraPrison.prison = true;
            }
        }
        if (restart)
        {
            AllKill.AllKillMonster = false;
            GetComponent<BoxCollider>().enabled = true;
            breathShow.SetActive(false);
            charge.SetActive(false);
            boss.layer = 19;
            canvas.SetActive(false);
            bossSpone.SetActive(true);
            bossSpone.SetActive(false);
            boss.SetActive(false);
            stage3.GetComponent<AudioSource>().clip = stage3BGM;
            stage3.GetComponent<AudioSource>().Play();
            boss.GetComponent<BossSkill>().BreatOff();
            restart = false;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            boss.SetActive(true);
            target.transform.position = other.transform.position;
            currentSize = cameraMinSize;
            CameraMove.isMove = true;
            BossCamera.CameraChange(target);
            setMove = true;
            canvas.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            setBossPlayerRespone = true;

            stage3.GetComponent<AudioSource>().clip = BossBGM;
            stage3.GetComponent<AudioSource>().Play();
        }
    }
}
