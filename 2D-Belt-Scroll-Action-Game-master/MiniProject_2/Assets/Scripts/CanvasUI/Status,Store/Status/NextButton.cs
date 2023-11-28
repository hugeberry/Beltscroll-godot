    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public void NextUI()
    {
        transform.parent.parent.GetComponent<Animator>().SetTrigger("isStore");
    }

    public void NextEND()
    {
        transform.parent.parent.GetComponent<Animator>().SetTrigger("isEnd");
    }
}
