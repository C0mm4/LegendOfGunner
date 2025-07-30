using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject pauseUI;

    public void Awake()
    {
        if (Instance == null & Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (pauseUI.activeSelf) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }
}
