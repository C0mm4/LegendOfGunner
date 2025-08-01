using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static LevelUpModel;

public class LevelUpView : MonoBehaviour
{
    public TextMeshProUGUI[] nameText;
    public TextMeshProUGUI[] infoText;

    public void SetRewordUI(Queue<sCharacteristic> handGunQueue, Queue<sCharacteristic>[] randomReword)
    {
        var item1 = handGunQueue.Peek();       // queue ���濹��
        var item2 = randomReword[0].Peek();    // queue ���濹��
        var item3 = randomReword[1].Peek();    // queue ���濹��

        nameText[0].text = item1.name;
        nameText[1].text = item2.name;
        nameText[2].text = item3.name;

        infoText[0].text = item1.info;
        infoText[1].text = item2.info;
        infoText[2].text = item3.info;
    }
}
