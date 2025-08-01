using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartBtn : MonoBehaviour
{
    public Button startBtn;

    public void StartButtonClick()
    {
        SceneManager.LoadScene("InGameScene");
    }
}
