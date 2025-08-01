using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    AudioClip bgm1;
    [SerializeField]
    AudioClip bgm2;

    [SerializeField]
    AudioClip SFX1;
    [SerializeField]
    AudioClip SFX2;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManager.Instance.PlayBGM(bgm1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManager.Instance.PlayBGM(bgm2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SoundManager.Instance.PlaySFX(SFX1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SoundManager.Instance.PlaySFX(SFX2);
        }
    }
}
