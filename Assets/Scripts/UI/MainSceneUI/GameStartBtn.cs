using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameStartBtn : MonoBehaviour
{
    public Button startBtn;

    public void StartButtonClick()
    {
        try
        {
            SceneManager.LoadScene("InGameScene");
            GameManager.Instance.StartGame();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}
