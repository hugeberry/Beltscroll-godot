using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieSound : MonoBehaviour
{
    private VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.SetDirectAudioVolume(0, OptionData.BGMVolume);
    }
}
