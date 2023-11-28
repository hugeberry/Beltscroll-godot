using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//스테이지 이동 스크립트. 
public class CanvasUIManager : MonoBehaviour
{
    private GameObject load = null;

    public static string stage = "";

    private void Start()
    {
        load = GameObject.Find("progress");
    }

    private void OnEnable()
    {
        StatusCount.statucCount += 5;
    }

    public void OffActivity()
    {
        gameObject.SetActive(false);
    }

    public void NextStage()
    {
        load.SetActive(true);
        load.GetComponent<LodingScript>().LoadScene(stage);
    }
}
