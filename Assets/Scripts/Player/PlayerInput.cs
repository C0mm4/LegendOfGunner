using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 dir;
    
    void Update()
    {

        dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector3.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
        }

        dir.Normalize();

    }
}
