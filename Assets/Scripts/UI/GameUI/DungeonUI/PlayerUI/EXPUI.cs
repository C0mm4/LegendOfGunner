using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPUI : MonoBehaviour
{
    ResourceController resourceController;
    public RectTransform expGauge;
    public float RequireExp;
    public float CurrentExp;

    private void Start()
    {
        resourceController = FindObjectOfType<ResourceController>();
    }

    // Update is called once per frame
    void Update()
    {
        RequireExp = resourceController.RequireExp;
        CurrentExp = resourceController.Exp;
        float nowEXPWidth = (float)(CurrentExp/ RequireExp) * 360;
        expGauge.sizeDelta = new Vector2(nowEXPWidth, 25);
    }
}
