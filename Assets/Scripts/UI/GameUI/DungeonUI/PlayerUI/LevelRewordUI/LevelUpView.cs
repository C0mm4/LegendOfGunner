using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static LevelUpModel;

public class LevelUpView : MonoBehaviour
{
    public TextMeshProUGUI[] nameText;
    public TextMeshProUGUI[] infoText;

    public void SetRewordUI(List<sCharacteristic> handGunQueue, List<sCharacteristic>[] randomReword)
    {
        sCharacteristic? item1 = handGunQueue.Count != 0 ? handGunQueue[0] : null;       // queue 변경예정
        nameText[0].text = item1 == null ? "없습니다" : item1?.name;
        infoText[0].text = item1 == null ? "없습니다" : item1?.info;
        if (randomReword != null)
        {
            if (randomReword.Length >= 1)
            {
                var item2 = randomReword[0][0];    // queue 변경예정
                nameText[1].text = item2.name;
                infoText[1].text = item2.info;
                if (randomReword.Length == 2)
                {
                    var item3 = randomReword[1][0];    // queue 변경예정
                    nameText[2].text = item3.name;
                    infoText[2].text = item3.info;
                }
                else
                {
                    nameText[2].text = "없습니다";
                    infoText[2].text = "없습니다";
                }
            }
            else
            {
                nameText[1].text = "없습니다";
                infoText[1].text = "없습니다";

                nameText[2].text = "없습니다";
                infoText[2].text = "없습니다";
            }
        }

    }
}
