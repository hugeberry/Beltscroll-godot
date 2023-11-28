using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PresentsElastic : MonoBehaviour
{
    public GameObject SplashParticle;
    public GameObject SceneChange;
    public AudioClip SplashStart;
    public AudioClip SplashEnd;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = SplashStart;
        audio.Play();
        Invoke("ShowWaterSplash", 1.3f);
    }
    void ShowWaterSplash()
    {
        audio.Stop();
        audio.clip = SplashEnd;
        audio.PlayOneShot(audio.clip);
        Instantiate(SplashParticle, new Vector3(0, 0, 0), Quaternion.identity);
        Invoke("SceneClose", 1.5f);
    }
    void SceneClose()
    {
        SceneChange.GetComponent<Animator>().SetTrigger("isClose");
        Invoke("NextScene", 2.0f);
    }
    void NextScene()
    {
        SceneManager.LoadScene("login");
    }
}
