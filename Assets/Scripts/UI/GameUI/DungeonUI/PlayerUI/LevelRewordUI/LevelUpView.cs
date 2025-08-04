using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static LevelUpModel;

public class LevelUpView : MonoBehaviour
{
    public TextMeshProUGUI[] nameText;
    public TextMeshProUGUI[] infoText;

    public void SetRewordUI(List<Attribute> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            nameText[i].text = list[i].GetName;
            infoText[i].text = list[i].GetDesc;
        }

    }
}
