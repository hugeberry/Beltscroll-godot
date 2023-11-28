using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    private GameObject canvas = null;
    public GameObject main = null;
    private bool active = false;

    public Slider BGMSlider;
    public Slider FXSlider;
    private float BGMsound = 0.5f;
    private float FXsound = 0.5f;

    private PlayerMovement playerMove = null;
    private GameObject player = null;

    private GameObject progress = null;

    private void Start()
    {
        canvas = transform.GetChild(1).gameObject;
        BGMsound = OptionData.BGMVolume;
        FXsound = OptionData.FXVolume;
        progress = GameObject.Find("progress");
        player = GameObject.Find("PlayerParent").transform.GetChild(0).gameObject;
        playerMove = player.GetComponent<PlayerMovement>();

    }
    private void OnEnable()
    {
        BGMSlider.value = OptionData.BGMVolume;
        FXsound = OptionData.FXVolume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(transform.GetChild(0).gameObject.activeSelf != true && transform.GetChild(2).gameObject.activeSelf != true)
                ActivityController();
        }
    }

    public void ActivityController()
    {
        active = !active;
        canvas.SetActive(active);
        Time.timeScale = TrunBool(active);
    }
    public void Active()
    {
        active = !active;
    }

    private int TrunBool(bool active)
    {
        if (active == true)
            return 0;
        else
            return 1;
    }

    public void ToTitle()
    {
        ActivityController();
        Application.LoadLevel(2);
        DestroyObject(main);
        CameraPrison.prison = false;
        DontDestroyOnLoadMain.NeverDestroyMain = null;
    }

    public void Restart()
    {
        playerMove.death.SampleAnimation(player, 0);
        if (CameraChage.setBossPlayerRespone == true)
        {
            ActivityController();
            ReTryBoss();
        }
        else
        {
            PlayerTotalData.GetData();
            DestroyObject(main);
            ActivityController();
            canvas.SetActive(active);
            Time.timeScale = TrunBool(active);
            progress.GetComponent<LodingScript>().LoadScene("MainScene");
        }
        CameraPrison.prison = false;
        transform.GetChild(2).gameObject.SetActive(false);
    }

    private void ReTryBoss()
    {
        GameObject target = GameObject.Find("PlayerParent").transform.GetChild(0).gameObject;
        BossCamera.CameraChange(target);
        BossCamera.CameraZomeOut(11);
        CameraPrison.prison = false;
        CameraChage.restart = true;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void BGMSliderChange()
    {
        OptionData.BGMVolume = BGMSlider.value;
    }
    public void FXSliderChange()
    {
        OptionData.FXVolume = FXSlider.value;
    }

    public void ApplyBGMSlider()
    {
        BGMsound = BGMSlider.value;
        FXsound = FXSlider.value;
        OptionData.BGMVolume = BGMsound;
        OptionData.FXVolume = FXsound;
    }

    public void CancelBGMSlider()
    {
        OptionData.BGMVolume = BGMsound;
        OptionData.FXVolume = FXsound;
    }

    public void ClickOption()
    {
        BGMSlider.value = BGMsound;
        FXSlider.value = FXsound;
    }
}
