using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//타르티를 얼마나 생성할 것인가
public class ResponeTarrtea : MonoBehaviour
{
    //얼마나 생성할 것인지
    public int howMany;
    private void OnEnable()
    {
        TarrteaArray.ResponeTarrtea(transform, howMany);
    }
}
