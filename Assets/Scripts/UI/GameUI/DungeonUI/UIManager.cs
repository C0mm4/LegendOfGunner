using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject pauseUI;
    public GameObject pauseMenu; 
    public GameObject levelUPRewordUI;
    public GameObject StatusUI;
    public GameObject gameEndUI = null;
    public bool pause;
    protected override void Awake()
    {
        base.Awake();

        pauseUI.SetActive(false);
        pauseMenu.SetActive(false);
        StatusUI.SetActive(false);
    }

    public void ActiveGameEndUI(bool isDie)
    {
        if (gameEndUI != null)
        {
            gameEndUI.SetActive(true);
        }
    }

    public void ActiveLevelUPUI()
    {
        if(levelUPRewordUI != null)
        {
            levelUPRewordUI.SetActive(true);
        }
    }
}
