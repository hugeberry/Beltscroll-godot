using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//몬스터 리스폰 지점 스크립트
public class ResponPoint : MonoBehaviour
{
    //얼마나 생성할 것인지
    public int b_many;
    public int tt_many;
    public int t_many;
    private void OnEnable()
    {
        BurgyArray.ResponeBurgy(transform, b_many);
        TarrteaArray.ResponeTarrtea(transform, tt_many);
        TracanArray.ResponeTracan(transform, t_many);
    }

    public void sponed()
    {
        this.enabled = true;
        this.enabled = false;
    }
}
