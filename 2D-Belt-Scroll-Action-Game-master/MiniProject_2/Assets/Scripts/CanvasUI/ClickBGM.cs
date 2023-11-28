using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBGM : MonoBehaviour
{
    public AudioClip click = null;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(click);
        }
    }
}
