using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool isEnable = false;

    DungeonManager dungeon;

    private void OnEnable()
    {
        dungeon = GetComponentInParent<DungeonManager>();
        isEnable = true;
    }

    private void OnDisable()
    {
        isEnable = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isEnable) return;
        if(dungeon != null)
        {
            if (other.CompareTag("Player"))
            {
                dungeon.StartDungeon();
            }
        }
    }
}
