using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab2 : MonoBehaviour
{
    public InputField name, id, pw, con;
    void Update()
    {
        if (name.isFocused == true)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                id.Select();
            }
        }

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
                con.Select();
            }
        }
        if (con.isFocused == true)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                name.Select();
            }
        }
    }
}
