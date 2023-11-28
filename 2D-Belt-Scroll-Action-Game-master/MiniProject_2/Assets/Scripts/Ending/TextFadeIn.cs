using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextFadeIn : MonoBehaviour
{
    Text text;
    void Awake()
    {
        text = GetComponent<Text>();
        StartCoroutine(FadeTextToFullAlpha());
    }



    public IEnumerator FadeTextToFullAlpha()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 1));
            yield return null;
        }
    }
}
