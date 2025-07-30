using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementManager : MonoSingleton<AchivementManager>
{
    private List<Achievement> achievements = new List<Achievement>();

    // ���ǿ� ������ �� �ְ� ���� (��: ų ī��Ʈ)
    private KillByIDCondition killCountCondition;

    void Start()
    {
        // Add Initialize Achievements
        
    }

    public void AddKill()
    {
        killCountCondition.AddKill(1);
        CheckAchievements();
    }

    public void CheckAchievements()
    {
        foreach (var a in achievements)
        {
            a.CheckUnlock();
        }
    }
}
