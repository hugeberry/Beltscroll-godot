using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//힐
public class AnimHealPosition : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 po = new Vector3(player.transform.position.x + 1, player.transform.position.y - 2, player.transform.position.z);
        transform.position = po;
    }
}
