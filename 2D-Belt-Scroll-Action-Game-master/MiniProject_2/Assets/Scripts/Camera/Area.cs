using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public GameObject spone1 = null;
    public GameObject spone2 = null;
    private void OnEnable()
    {
        CameraPrison.dieCount = 0;
        CameraPrison.prison = true;
        spone1.SetActive(true);
        spone2.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
