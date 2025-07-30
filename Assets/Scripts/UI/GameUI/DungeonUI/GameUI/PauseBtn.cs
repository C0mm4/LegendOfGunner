using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    public bool isPauseOn = false;
    GameObject pauseUI;
    private void Start()
    {
        pauseUI = UIManager.Instance.pauseUI; 
    }
    public void PasueBtnClick()
    {
        pauseUI.SetActive(true);
        isPauseOn = true;
    }
}
