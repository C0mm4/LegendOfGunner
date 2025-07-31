using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    ResourceController resourceController;
    public RectTransform hpBar;
    public RectTransform hpGauge;
    private float MaxHealth;
    private float CurrentHealth;

    private void Start()
    {
        resourceController = FindObjectOfType<ResourceController>();
    }

    void Update()
    {
        MaxHealth = resourceController.MaxHealth;
        CurrentHealth = resourceController.CurrentHealth;
        float nowHPWidth = (CurrentHealth/MaxHealth) * 16;                        // maxHP, nowHP�� ĳ���Ͳ� ��������
        float maxHPWidth = CurrentHealth > 0 ? MaxHealth * 16 : 0;                            // ü�� 1�� ���� 18. �ִ� 36
        hpBar.sizeDelta = new Vector2(maxHPWidth, 25);
        hpGauge.sizeDelta = new Vector2(nowHPWidth, 25);
    }
}
