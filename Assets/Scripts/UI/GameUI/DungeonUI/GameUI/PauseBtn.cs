using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    GameObject pauseUI;
    GameObject pauseMenu;
    private void Start()
    {
        pauseUI = UIManager.Instance.pauseUI;
        pauseMenu = UIManager.Instance.pauseMenu;
    }
    public void PasueBtnClick()
    {
        if (pauseUI.activeSelf) return;
        pauseUI.SetActive(true);
        pauseMenu.SetActive(true);
        GameManager.Instance.PauseGame();
    }
}
