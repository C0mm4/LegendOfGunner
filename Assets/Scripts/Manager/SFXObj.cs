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
            Debug.LogWarning("AudioSource에 Clip이 없습니다. 오브젝트를 즉시 파괴합니다.");
            Destroy(gameObject);
            return;
        }

        source.Play();
//        Destroy(gameObject, source.clip.length);
    }
}
