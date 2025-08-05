using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{
    [SerializeField]
    private GameObject gameEndObject;

    [SerializeField]
    private TextMeshProUGUI gameOverAndClearText;

    [SerializeField]
    private TextMeshProUGUI currentRoundText;

    [SerializeField]
    private TextMeshProUGUI topRecordRoundText;

    public void GoToMainMenu()
    {
        GameManager.Instance.GoToTitle();
    }

    public void EndGame(bool isDie)
    {
        gameOverAndClearText.text = isDie == true ? "GameOver" : "GameClear";
        //currentRoundText.text = GameManager.Instance.NextStage
    }
}
