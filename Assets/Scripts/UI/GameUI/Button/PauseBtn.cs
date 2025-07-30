using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    bool isPauseUIOn = false;
    public GameObject pauseUI;
    public void PasueBtnClick()
    {
        pauseUI.SetActive(true);
        isPauseUIOn = true;
    }
    private void Update()
    {

    }
}
