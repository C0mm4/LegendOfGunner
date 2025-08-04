using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    Attribute testAttrib;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            testAttrib.ApplyAttribute();
        }
    }

    
}
