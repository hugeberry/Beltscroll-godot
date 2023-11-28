using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillpointer : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("PlayerParent").transform.GetChild(0).gameObject;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 5f, -4.5f);
    }
}
