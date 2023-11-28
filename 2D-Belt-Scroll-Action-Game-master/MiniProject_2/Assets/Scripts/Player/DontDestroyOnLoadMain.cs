using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadMain : MonoBehaviour
{
    public static GameObject NeverDestroyMain = null;
    void Start()
    {
        if (NeverDestroyMain == null)
        {
            DontDestroyOnLoad(gameObject);
            NeverDestroyMain = gameObject;
        }
    }
}
