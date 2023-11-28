using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MovieSceneLoad : MonoBehaviour
{
    public GameObject press = null;

    private void Start()
    {
        Invoke("StartStage",20f);
    }

    public void StartStage()
    {
        press.SetActive(true);
        press.GetComponent<LodingScript>().LoadScene("MainScene");
    }
}
