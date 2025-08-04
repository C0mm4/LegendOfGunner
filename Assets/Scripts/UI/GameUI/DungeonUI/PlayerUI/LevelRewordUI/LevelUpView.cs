using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static LevelUpModel;

public class LevelUpView : MonoBehaviour
{
    public TextMeshProUGUI[] nameText;
    public TextMeshProUGUI[] infoText;

    public void SetRewordUI(Queue<Attribute> handGunQueue, Queue<Attribute>[] randomReword)
    {
        var item1 = handGunQueue.Dequeue();       // queue 변경예정
        var item2 = randomReword[0].Dequeue();    // queue 변경예정
        var item3 = randomReword[1].Dequeue();    // queue 변경예정

        Debug.Log(item1.name);
        Debug.Log(item2.name);
        Debug.Log(item3.name);

        nameText[0].text = item1.GetName;
        nameText[1].text = item2.GetName;
        nameText[2].text = item3.GetName;

        infoText[0].text = item1.GetDesc;
        infoText[1].text = item2.GetDesc;
        infoText[2].text = item3.GetDesc;
    }
}
