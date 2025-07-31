using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPUI : MonoBehaviour
{
    public RectTransform expGauge;
    public int maxEXP;
    public int nowEXP;

    // Update is called once per frame
    void Update()
    {
        float nowEXPWidth = (float)nowEXP / (float)maxEXP * 100 * 18;
        expGauge.sizeDelta = new Vector2(nowEXPWidth, 25);
    }
}
