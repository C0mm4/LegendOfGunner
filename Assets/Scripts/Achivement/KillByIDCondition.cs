using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillByIDCondition : IAchievementCondition
{
    private Dictionary<int, int> killCounts = new();
    private Dictionary<int, int> reqCounts = new();

    public KillByIDCondition(Dictionary<int, int> requires)
    {
        reqCounts = requires;
        foreach (var req in reqCounts)
        {
            killCounts[req.Key] = req.Value;
        }
    }

    public void AddKill(int enemyID)
    {
        if(killCounts.ContainsKey(enemyID))
            killCounts[enemyID]++;
    }

    public bool IsSatisfied()
    {
        foreach (var kvp in reqCounts)
        {
            if (killCounts[kvp.Key] < kvp.Value)
                return false;
        }
        return true;
    }
}
