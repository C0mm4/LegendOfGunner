using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundUI : MonoBehaviour
{
    DungeonManager dungeonManager;

    public TMP_Text RoundText;

    private void Start()
    {
        dungeonManager = FindObjectOfType<DungeonManager>();
    }

    private void Update()
    {
        RoundText.text = $"{dungeonManager.stage} - {dungeonManager.wave} round";
    }
}
