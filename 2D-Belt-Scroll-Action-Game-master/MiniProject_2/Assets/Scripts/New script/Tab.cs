using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    public InputField id, pw;
    void Update()
    {
        if (id.isFocused == true)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                pw.Select();
            }
        }

        if (pw.isFocused == true)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                id.Select();
            }
        }
    }
}
