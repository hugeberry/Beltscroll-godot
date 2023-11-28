using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoad : MonoBehaviour
{
    void Awake()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        Application.LoadLevelAdditive(PlayerTotalData.star);
    }
}
