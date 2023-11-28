using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStatus : MonoBehaviour
{
    public Vector3 movePlayerEnd;
    public GameObject statusUI;
    public GameObject player;
    public string nextStage;
    private PlayerMovement p_movement;
    private IntroMove p_intro;
    private bool isOne = false;
    private void OnEnable()
    {
        statusUI = GameObject.Find("CanvasUI");
        player = GameObject.Find("PlayerParent").transform.GetChild(0).gameObject;
        p_movement = player.GetComponent<PlayerMovement>();
        p_intro = player.GetComponent<IntroMove>();
        isOne = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (isOne && p_movement.IsGround())
            {
                isOne = false;
                other.gameObject.layer = 0;
                StartCoroutine("offActivity");
                statusUI.transform.GetChild(0).gameObject.SetActive(true);
                p_movement.enabled = false;
                p_intro.getAxis = movePlayerEnd;
                p_intro.enabled = true;
                CanvasUIManager.stage = nextStage;
            }
        }
    }

    IEnumerator offActivity()
    {
        yield return new WaitForSeconds(2.5f);
        player.SetActive(false);
    }
}
