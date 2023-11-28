using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject SceneChange;
    public GameObject[] Monster;
    public GameObject Player;
    public Slider BGMSlider;
    public Slider FXSlider;
    public GameObject Load;
    private float BGMsound = OptionData.BGMVolume;
    private float FXsound = OptionData.FXVolume;

    private float timer = 0.0f;
    private float speed = 5.0f;
    private float dir = 1.0f;
    private float PlayerRotate = 0.5f;
    private float MonsterRotate = 0.5f;
    private int MonsterRotateCount = 2;
    private AudioSource audio;

    private void OnEnable()
    {
        if (PlayFabManager.NL == 0)
        {
            Load.SetActive(false);
        }
        else
        {
            Load.SetActive(true);
        }

        SceneChange.GetComponent<Animator>().SetTrigger("isOpen");
        Invoke("OffSceneChange", 0.5f);
        for (int i = 0; i < Monster.Length; i++)
            Monster[i].GetComponent<Animator>().SetBool("isMove", true);
        audio = GetComponent<AudioSource>();
        BGMSlider.value = OptionData.BGMVolume;
        FXSlider.value = OptionData.FXVolume;
        FXsound = OptionData.FXVolume;
        audio.volume = OptionData.BGMVolume;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Player.transform.Translate(Vector3.right * dir * speed * Time.deltaTime);
        for (int i = 0; i < Monster.Length; i++)
            Monster[i].transform.Translate(Vector3.right * dir * speed * Time.deltaTime);
        if(timer >= 6.0f)
        {
            MonsterRotateCount++;
            if(MonsterRotateCount % 2 == 1)
            {
                for (int i = 0; i < Monster.Length; i++)
                {
                    Monster[i].GetComponent<Animator>().SetBool("isAttack", true);
                    Monster[i].GetComponent<Animator>().SetBool("isMove", false);
                }
                Player.GetComponent<Animator>().SetBool("isRun", true);
            }
            else
            {
                for (int i = 0; i < Monster.Length; i++)
                {
                    Monster[i].GetComponent<Animator>().SetBool("isAttack", false);
                    Monster[i].GetComponent<Animator>().SetBool("isMove", true);
                }
                Player.GetComponent<Animator>().SetBool("isRun", false);
            }
            dir = -dir;
            PlayerRotate = -PlayerRotate;
            MonsterRotate = -MonsterRotate;
            Player.transform.localScale = new Vector3(PlayerRotate, 0.5f, 0.5f);
            for (int i = 0; i < Monster.Length; i++)
                Monster[i].transform.localScale = new Vector3(MonsterRotate, 0.5f, 0.5f);
            timer = 0.0f;
        }
    }
    public void NewGame()
    {
        SceneChange.SetActive(true);
        SceneChange.GetComponent<Animator>().SetTrigger("isClose");
        Invoke("NewScene", 1.5f);
    }

    public void LoadGame()
    {
        SceneChange.SetActive(true);
        SceneChange.GetComponent<Animator>().SetTrigger("isClose");
        Invoke("NextScene", 1.5f);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void OffSceneChange()
    {
        SceneChange.SetActive(false);
    }
    private void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void NewScene()
    {
        SceneManager.LoadScene("Movie");
    }
    public void BGMSliderChange()
    {
        OptionData.BGMVolume = BGMSlider.value;
        audio.volume = OptionData.BGMVolume;
    }
    public void FXSliderChange()
    {
        OptionData.FXVolume = FXSlider.value;
    }

    public void Logout()
    {
        DestroyObject(GameObject.Find("PlayFabManager"));
        Application.LoadLevel(0);
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
        audio.volume = OptionData.BGMVolume;
    }

    public void ClickOption()
    {
        BGMSlider.value = BGMsound;
        FXSlider.value = FXsound;
    }
}
