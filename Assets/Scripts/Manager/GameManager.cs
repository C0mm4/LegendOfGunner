using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    // To Do List
    // object change to playercontroller
    public static object PlayerInstance;

    public bool isFirstRun = false;
    public readonly string firstRunKey = "isFirstRun";

    public bool isPause = false;

    [SerializeField]
    private bool DebugMode = false;

    protected override void Awake()
    {
        base.Awake();

        if (DebugMode)
        {
            // 최초 실행 시 동작
            if (PlayerPrefs.HasKey(firstRunKey))
            {
                isFirstRun = PlayerPrefs.GetInt(firstRunKey) == 1 ? true : false;
                // 2회차 실행 시 게임 데이터 로드 추가

                LoadGameData();
            }
            else
            {
                isFirstRun = false;
                // 최초 실행 시 게임 데이터 초기화

                InitializeGameData();
            }
        }
        else
        {
            InitializeGameData();
        }

        PlayerPrefs.SetInt(firstRunKey, 1);

        // 해상도 FHD
        Screen.SetResolution(1920, 1080, true);
    }


    /// <summary>
    /// 최초 실행시 게임 데이터 초기화
    /// </summary>
    private void InitializeGameData()
    {

    }

    /// <summary>
    /// 게임 데이터 로드
    /// </summary>
    private void LoadGameData()
    {

    }

    /// <summary>
    /// 게임 시작
    /// </summary>
    public void StartGame()
    {

    }

    /// <summary>
    /// 게임 일시정지, 토글 방식
    /// </summary>
    public void PauseGame()
    {
        isPause = !isPause;
        Time.timeScale = isPause ? 0f : 1f;
    }

    /// <summary>
    /// 게임 종료
    /// </summary>
    public void EndGame()
    {

    }

    /// <summary>
    /// 스테이지 클리어 시 처리
    /// </summary>
    public void ClearStage()
    {

    }

    /// <summary>
    /// 다음 방 진입
    /// </summary>
    public void NextStage()
    {

    }
}
