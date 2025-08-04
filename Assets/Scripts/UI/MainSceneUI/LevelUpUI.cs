using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    public Task<int> SelectValue()
    {
        int selectNum = 0;
        return Task.FromResult(selectNum);
    }
}
