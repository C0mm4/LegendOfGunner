using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public static UIManager Instance;
    public GameObject pauseUI;
    public GameObject pauseMenu;
    public GameObject StatusUI;
    public bool pause;

    protected override void Awake()
    {
        base.Awake();

        pauseUI.SetActive(false);
        pauseMenu.SetActive(false);
        StatusUI.SetActive(false);
    }

    void Update()
    {
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else Time.timeScale = 1f;
    }
}
