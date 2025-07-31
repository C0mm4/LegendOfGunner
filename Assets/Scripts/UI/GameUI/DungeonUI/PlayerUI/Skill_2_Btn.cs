using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Net;


public class Skill_2_Btn : MonoBehaviour
{
    public float maxCoolDown; // 쿨타임 받아와야함
    public Image coolDownIcon;
    public TextMeshProUGUI coolDownText;
    float coolDown;
    bool isCoolDown = false; // true - 스킬 사용 불가, false - 스킬 사용 가능

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            ClickSkill_2_Btn();
        }
    }

    public void ClickSkill_2_Btn()
    {
        //스킬 사용 메서드
        if (isCoolDown) return;
        StartCoroutine(CoolDownTime(maxCoolDown));
    }

    IEnumerator CoolDownTime(float maxCoolDownTime)
    {
        coolDown = maxCoolDownTime;
        SetCoolDown(true);

        while (coolDown > 0)
        {
            if (UIManager.Instance.pauseUI.activeSelf)
            {
                yield return null;
                continue;
            }

            coolDown -= Time.deltaTime;
            coolDownIcon.fillAmount = coolDown / maxCoolDown;
            coolDownText.text = coolDown.ToString("N1");
            yield return null;
        }

        SetCoolDown(false);
    }

    void SetCoolDown(bool boolean)
    {
        isCoolDown = boolean;
        coolDownText.gameObject.SetActive(boolean);
        coolDownIcon.gameObject.SetActive(boolean);
    }
}
