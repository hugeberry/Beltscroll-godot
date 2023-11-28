using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public bool isGround = false;
    Vector3 scale = new Vector3(2.5f,0.5f,0.7f);
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, scale, 0.1f);
        if (isGround && Input.GetKeyDown(KeyCode.X))
        {
            scale.x = 2.0f;
            scale.z = 0.5f;
            Invoke("returnShadow", 0.5f);
        }
    }

    public void returnShadow()
    {
        scale.x = 2.5f;
        scale.z = 0.7f;
    }
}
