using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Title, Load, Menu, InPlay
}

public class GameManager : MonoSingleton<GameManager>
{
    // To Do List
    // object change to playercontroller
    [SerializeField]
    private static PlayerController player;
    public static PlayerController PlayerInstance
    {
        get 
        {
            if (player == null)
                player = FindAnyObjectByType<PlayerController>();
            return player;
        }
    }

    public static GameState gameState = GameState.Title;

    public bool isFirstRun = false;
    public readonly string firstRunKey = "isFirstRun";

    public bool isPause = false;

    [SerializeField]
    private bool DebugMode = false;


    [SerializeField]
    private AudioClip TitleBGM;
    [SerializeField]
    private AudioClip InGameBGM;

    protected override void Awake()
    {
        base.Awake();
        if (!DebugMode)
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
            // 디버그 모드 시 로드 없이 초기화
            InitializeGameData();
        }

        PlayerPrefs.SetInt(firstRunKey, 1);

        // 해상도 FHD
        Screen.SetResolution(1920, 1080, true);


        gameState = GameState.Title;
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM(TitleBGM);
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
        SceneManager.LoadScene("InGameScene");
        SoundManager.Instance.PlayBGM(InGameBGM);
        isPause = true;
        Time.timeScale = 1f;
        AttributeManager.Instance.Init();
    }

    /// <summary>
    /// 게임 일시정지, 토글 방식
    /// </summary>
    public void PauseGame()
    {
        isPause = false;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// 게임 종료
    /// </summary>
    public void EndGame()
    {
        isPause = true;
        Time.timeScale = 0;
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

    public void GoToTitle()
    {
        ProjectileManager.Instance.MoveToTitle();
        SceneManager.LoadScene("MainScene");
        SoundManager.Instance.PlayBGM(TitleBGM);
    }
}
