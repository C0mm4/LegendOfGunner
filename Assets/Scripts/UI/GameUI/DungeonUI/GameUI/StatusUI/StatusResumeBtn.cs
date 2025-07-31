using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusResumeBtn : MonoBehaviour
{
    GameObject statusUI;

    private void Start()
    {
        statusUI = UIManager.Instance.StatusUI;
    }
    public void ClickStatusResumeBtn()
    {
        statusUI.SetActive(false);
    }
}
