using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    Attribute testAttrib;
    [SerializeField]
    Attribute testAttrib1;
    [SerializeField]
    Attribute testAttrib2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            testAttrib.ApplyAttribute();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            testAttrib1.ApplyAttribute();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            testAttrib2.ApplyAttribute();
        }
    }

    
}
