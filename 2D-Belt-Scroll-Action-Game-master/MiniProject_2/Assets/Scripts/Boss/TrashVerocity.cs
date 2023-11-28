using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashVerocity : MonoBehaviour
{
    void Update()
    {
        transform.right = GetComponent<Rigidbody>().velocity;
    }
}
