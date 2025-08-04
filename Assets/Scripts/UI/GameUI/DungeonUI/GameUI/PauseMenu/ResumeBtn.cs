using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : MonoBehaviour
{
    GameObject pauseUI;
    public void Start()
    {
        pauseUI = UIManager.Instance.pauseUI;
    }
    public void ClickResumeBtn()
    {
        pauseUI.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
}
