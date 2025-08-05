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
            // ���� ���� �� ����
            if (PlayerPrefs.HasKey(firstRunKey))
            {
                isFirstRun = PlayerPrefs.GetInt(firstRunKey) == 1 ? true : false;
                // 2ȸ�� ���� �� ���� ������ �ε� �߰�

                LoadGameData();
            }
            else
            {
                isFirstRun = false;
                // ���� ���� �� ���� ������ �ʱ�ȭ

                InitializeGameData();
            }
        }
        else
        {
            // ����� ��� �� �ε� ���� �ʱ�ȭ
            InitializeGameData();
        }

        PlayerPrefs.SetInt(firstRunKey, 1);

        // �ػ� FHD
        Screen.SetResolution(1920, 1080, true);


        gameState = GameState.Title;
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM(TitleBGM);
    }



    /// <summary>
    /// ���� ����� ���� ������ �ʱ�ȭ
    /// </summary>
    private void InitializeGameData()
    {

    }

    /// <summary>
    /// ���� ������ �ε�
    /// </summary>
    private void LoadGameData()
    {

    }

    /// <summary>
    /// ���� ����
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
    /// ���� �Ͻ�����, ��� ���
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
    /// ���� ����
    /// </summary>
    public void EndGame()
    {
        isPause = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// �������� Ŭ���� �� ó��
    /// </summary>
    public void ClearStage()
    {
        
    }

    /// <summary>
    /// ���� �� ����
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
