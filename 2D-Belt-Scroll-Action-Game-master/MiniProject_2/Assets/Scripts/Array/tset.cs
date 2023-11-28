using ArrayPulling;
using MyFSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tset : MonoBehaviour
{
    private ArrayObject<int> aa = new ArrayObject<int>();

    private void Start()
    {
        Debug.Log(aa.length); //0
        aa.add(1);
        Debug.Log(aa.length); //1
        aa.add(2);
        Debug.Log(aa.length); //2
        aa.remove(0);
        Debug.Log(aa.length); //1

        for (int i = 0; i < aa.length; i++)
        {
            Debug.Log(aa.get(i));
        }

    }


}
