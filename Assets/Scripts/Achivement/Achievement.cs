using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement 
{
    public string Name {  get; private set; }
    public string Desc { get; private set; }

    public bool IsUnlock { get; private set; }


    private IAchievementCondition condition;

    public Achievement(string name, string desc, bool unLock, IAchievementCondition condi)
    {
        Name = name;
        Desc = desc;
        IsUnlock = unLock;
        condition = condi;
    }

    public void CheckUnlock()
    {
        if (IsUnlock) return;
        if (condition == null) return;
        if (condition.IsSatisfied())
        {
            IsUnlock = true;
            Debug.Log($"{Name} Unlock");
        }
    }

}

