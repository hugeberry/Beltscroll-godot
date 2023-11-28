using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{

    public InputField EmailInput, NewEmailInput, PasswordInput, NewPasswordInput, UsernameInput, Confirm;//이메일,가입 이메일,패스워드,가입 패스워드,이름,비번확인
    public Text LogText, ReText;//결과 출력
    public GameObject Lo, Re;//메뉴, 로그인창, 가입창
    public static string EM, PW;

    public static int NL = 1;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    //로그인
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = EmailInput.text, Password = PasswordInput.text };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        EM = EmailInput.text;
        PW = PasswordInput.text;
    }
    void OnLoginSuccess(LoginResult result)
    {
        PlayerTotalData.GetData();
        Debug.Log(result);
        LogText.text = "로그인 성공!";
        StartCoroutine("LoadPanelCoroutine");
    }

    IEnumerator LoadPanelCoroutine()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Title");
    }

    void OnLoginFailure(PlayFabError error)
    {
        LogText.text = "아이디나 비밀번호를 확인하세요";
    }
    //회원가입
    public void Register()
    {
        var request = new RegisterPlayFabUserRequest { Email = NewEmailInput.text, Password = NewPasswordInput.text, Username = UsernameInput.text };
        if (NewPasswordInput.text == Confirm.text)
        {
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
        }
        else { print("비밀번호 에러"); ReText.text = "비번이 일치하지 않습니다."; }
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        LogText.text = "가입에 성공하였습니다.";
        Lo.active = true;
        Re.active = false;
        NL = 1;
    }
    void OnRegisterFailure(PlayFabError error) {print("회원가입 실패");ReText.text = "가입에 실패하였습니다.";}
}