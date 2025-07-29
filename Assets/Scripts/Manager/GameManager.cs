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
            InitializeGameData();
        }

        PlayerPrefs.SetInt(firstRunKey, 1);

        // �ػ� FHD
        Screen.SetResolution(1920, 1080, true);
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

    }

    /// <summary>
    /// ���� �Ͻ�����, ��� ���
    /// </summary>
    public void PauseGame()
    {
        isPause = !isPause;
        Time.timeScale = isPause ? 0f : 1f;
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void EndGame()
    {

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
}
