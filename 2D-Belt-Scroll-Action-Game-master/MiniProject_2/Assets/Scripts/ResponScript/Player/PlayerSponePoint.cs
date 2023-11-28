using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSponePoint : MonoBehaviour
{
    public Vector3 go = Vector3.zero;
    public GameObject player = null;

    private void OnEnable()
    {
        player = GameObject.Find("PlayerParent").transform.GetChild(0).gameObject;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<IntroMove>().enabled = true;
        player.GetComponent<IntroMove>().getAxis = go;
        player.transform.position = transform.position;
        player.SetActive(true);
    }
}
