using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameExitBtn : MonoBehaviour
{
    public Button exitButton;
    public void ExitButtonClick()
    {
        Debug.Log("게임 종료 시도 - 빌드 시 반영됨");
        Application.Quit();
    }
}
