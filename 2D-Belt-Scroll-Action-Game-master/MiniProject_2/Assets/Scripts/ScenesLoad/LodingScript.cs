using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

//로딩 ㅎ화면 스크립트
public class LodingScript : MonoBehaviour
{
    [SerializeField] private Text progressText;
    [SerializeField] private Slider slider;

    private AsyncOperation operation; //비동기식 ? 
    private GameObject canvas;

    public static GameObject NeverDestroyProgress = null;
    void Awake()
    {
        canvas = transform.GetChild(0).gameObject;
        if (NeverDestroyProgress == null)
        {
            DontDestroyOnLoad(gameObject);
            NeverDestroyProgress = gameObject;
        }
    }

    public void LoadScene(string sceneName)
    {
        UpdateProgressUI(0);
        canvas.SetActive(true);

        StartCoroutine(BeginLoad(sceneName));
    }

    private IEnumerator BeginLoad(string sceneName) {
        operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            UpdateProgressUI(operation.progress);
            yield return null;
        }

        UpdateProgressUI(operation.progress);
        operation = null;
        canvas.SetActive(false);
    }

    private void UpdateProgressUI(float progress)
    {
        int prog = (int)(progress * 100f);
        if (prog != 100)
        {
            slider.value = progress;
            progressText.text = prog + "";
        }
        else
            progressText.text = "아무 키나 눌러 주세요.";
    }

}
