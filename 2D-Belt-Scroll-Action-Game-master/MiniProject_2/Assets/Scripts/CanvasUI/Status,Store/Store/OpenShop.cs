using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject[] button;

    private void OnEnable()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(true);
        }
    }
}
