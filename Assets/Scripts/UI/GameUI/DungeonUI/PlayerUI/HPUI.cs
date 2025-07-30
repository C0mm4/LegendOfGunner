using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public RectTransform hpBar;
    public RectTransform hpGauge;
    public int maxHP = 20;
    public int nowHP = 20;

    void Update()
    {
        int nowHPWidth = nowHP * 18;                        // maxHP, nowHP�� ĳ���Ͳ� ��������
        int maxHPWidth = nowHP > 0 ? maxHP * 18 : 0;                            // ü�� 1�� ���� 18. �ִ� 36
        hpBar.sizeDelta = new Vector2(maxHPWidth, 25);
        hpGauge.sizeDelta = new Vector2(nowHPWidth, 25);
    }
}
