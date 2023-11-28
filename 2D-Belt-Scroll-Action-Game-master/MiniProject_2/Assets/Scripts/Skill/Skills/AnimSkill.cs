using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSkill : MonoBehaviour
{
    public void OffActivity()
    {
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }
}
