using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBtn : MonoBehaviour
{
    GameObject statusUI;

    private void Start()
    {
        statusUI = UIManager.Instance.StatusUI;
    }
    public void ClickStatusBtn()
    {
        statusUI.SetActive(true);
    }
}
