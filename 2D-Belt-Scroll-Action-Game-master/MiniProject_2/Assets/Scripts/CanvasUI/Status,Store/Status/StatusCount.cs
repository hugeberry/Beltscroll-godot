using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatusCount : MonoBehaviour
{
    public static int statucCount = 0;

    private void Update()
    {
        GetComponent<Text>().text = "Status Points : " + statucCount;
    }
}
