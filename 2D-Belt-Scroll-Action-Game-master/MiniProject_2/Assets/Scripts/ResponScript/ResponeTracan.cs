using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//트라켄을 얼마나 생성할 것인가
public class ResponeTracan : MonoBehaviour
{
    //얼마나 생성 할 지
    public int howMany = 0;

    private void OnEnable()
    {
        TracanArray.ResponeTracan(transform, howMany);
    }
}
