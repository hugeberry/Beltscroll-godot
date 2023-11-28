using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//버기를 얼마나 생성할것인가
public class ResponeBurgy : MonoBehaviour
{
    //얼마나 생성할 것인지
    public int howMany;
    private void OnEnable()
    {
        BurgyArray.ResponeBurgy(transform, howMany);
    }
}
