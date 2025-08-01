using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    protected RectTransform hpBar;
    protected TextMeshProUGUI nameText;
    private void Start()
    {
    }
    virtual public void SetActiveUI(string name)
    {
        hpBar = GameObject.Find("BossHpBar").GetComponent<RectTransform>();
        nameText = GameObject.Find("BossNameText").GetComponent<TextMeshProUGUI>();
        nameText.gameObject.SetActive(true);
        nameText.text = name;
        hpBar.gameObject.SetActive(true);
    }

    virtual public void SetHpBar(int maxHp, int hp)
    {
        if (hpBar == null) return;
        Vector2 size = hpBar.localScale;
        size.x -= 3.5f / maxHp;
        hpBar.localScale = size;
    }

    virtual public void DeActiveUI()
    {
        hpBar?.gameObject.SetActive(false);
        nameText?.gameObject.SetActive(false);
    }
}
