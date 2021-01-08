using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityRemover : MonoBehaviour
{
    public Rigidbody rb;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) 
            || Input.GetKeyDown(KeyCode.RightArrow) 
            || Input.GetKeyDown(KeyCode.UpArrow) 
            || Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector3.zero;
        }
    }
}
