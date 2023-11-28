using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class movie : MonoBehaviour
{
    void Start()
    {
        GetComponent<VideoPlayer>().Play();
    }
}
