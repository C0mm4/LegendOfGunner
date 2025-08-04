using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Net;


public class Skill_1_Btn : MonoBehaviour
{
    PlayerController playerController;
    public float maxCoolDown; // ��Ÿ�� �޾ƿ;���
    public Image coolDownIcon;
    public TextMeshProUGUI coolDownText;
    

 

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        BaseWeaponHandler weapon = playerController.GetWeapon(2);
        WeaponData data = weapon.data;
        if (data.IsCooltime)
        {
            float left = data.LeftCoolTime;
            float max = data.CoolTime;

            coolDownIcon.fillAmount = left / max;
            coolDownText.text = left.ToString("N1");

            coolDownText.gameObject.SetActive(true);
            coolDownIcon.gameObject.SetActive(true);
        }
        else
        {
            coolDownText.gameObject.SetActive(false);
            coolDownIcon.gameObject.SetActive(false);
        }
    }
}
