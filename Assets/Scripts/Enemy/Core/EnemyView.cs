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
    protected Animator animator;
    public AnimationClip clip;
    virtual public void SetActiveUI(string name,int hp, int maxHp)
    {
        hpBar = GameObject.Find("BossHpBar").GetComponent<RectTransform>();
        nameText = GameObject.Find("BossNameText").GetComponent<TextMeshProUGUI>();
        nameText.text = name;
        SetHpBar(hp, maxHp);
    }

    virtual public void SetHpBar(int maxHp, int hp)
    {
        if (hpBar == null) return;

        Vector3 size = hpBar.localScale;
        size.x = 3.5f / maxHp * hp;
        hpBar.localScale = size;
        Debug.Log("tqweoihb");
    }

    virtual public void DeActiveUI()
    {
        SetHpBar(0, 0);
        nameText.text = "";
    }

    virtual public void HitAnimaion()
    {
    }

    virtual public void AttackAnimation(int idx)
    {
    }
}
