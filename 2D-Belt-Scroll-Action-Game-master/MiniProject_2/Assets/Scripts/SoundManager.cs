using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //private float volume = TitleManager.volume;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = OptionData.BGMVolume;
    }
    private void Update()
    {
        audio.volume = OptionData.BGMVolume;
    }
}
