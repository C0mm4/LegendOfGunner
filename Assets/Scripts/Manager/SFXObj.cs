using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXObj : MonoBehaviour
{
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();

        if (source.clip == null)
        {
            Debug.LogWarning("AudioSource�� Clip�� �����ϴ�. ������Ʈ�� ��� �ı��մϴ�.");
            Destroy(gameObject);
            return;
        }

        source.Play();
//        Destroy(gameObject, source.clip.length);
    }
}
