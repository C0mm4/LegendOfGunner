using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static LevelUpModel;

public class LevelUpView : MonoBehaviour
{
    public TextMeshProUGUI[] nameText;
    public TextMeshProUGUI[] infoText;
    public TextMeshProUGUI[] levelText;

    public Image[] iconImages;
    public Sprite[] sprites;

    public void SetRewordUI(List<Attribute> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            iconImages[i].sprite = sprites[(int)(list[i].GetWeaponType)];
            nameText[i].text = list[i].GetName;
            infoText[i].text = list[i].GetDesc;
            levelText[i].text = $"Level {list[i].CurrentLevel} > {list[i].CurrentLevel + 1}";
        }

    }
}
