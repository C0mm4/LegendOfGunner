using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Skill_2_Btn : MonoBehaviour
{
    PlayerController playerController;
    public float maxCoolDown; // ��Ÿ�� �޾ƿ;���
    public Image coolDownIcon;
    public TextMeshProUGUI coolDownText;
    float coolDown;
    bool isCoolDown = false; // true - ��ų ��� �Ұ�, false - ��ų ��� ����

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        BaseWeaponHandler weapon = playerController.GetWeapon(3);
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
