using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoSingleton<SoundManager>
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string bgmVolumeParam = "BGMVolume";
    [SerializeField] private string sfxVolumeParam = "SFXVolume";

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSourcePrefab;

    private List<AudioSource> sfxSources = new List<AudioSource>();


    #region BGM

    public void PlayBGM(AudioClip newClip, bool loop = true, float fadeDuration = 1f)
    {
        if (bgmSource.clip == newClip) return;

        StopAllCoroutines(); // ���� ���̵� ����
        StartCoroutine(FadeAndSwitchBGM(newClip, loop, fadeDuration));
    }

    private IEnumerator FadeAndSwitchBGM(AudioClip newClip, bool loop, float fadeDuration)
    {
        // ���̵�ƿ�
        float currentVolume;
        audioMixer.GetFloat(bgmVolumeParam, out currentVolume);
        currentVolume = Mathf.Pow(10, currentVolume / 20f); // dB �� linear

        for (float t = 0; t < fadeDuration; t += Time.unscaledDeltaTime)
        {
            float v = Mathf.Lerp(currentVolume, 0f, t / fadeDuration);
            audioMixer.SetFloat(bgmVolumeParam, Mathf.Log10(Mathf.Max(v, 0.0001f)) * 20f);
            yield return null;
        }

        audioMixer.SetFloat(bgmVolumeParam, -80f); // ���� ���Ұ�

        // Ŭ�� ��ü
        bgmSource.Stop();
        bgmSource.clip = newClip;
        bgmSource.loop = loop;
        bgmSource.Play();

        // ���̵���
        for (float t = 0; t < fadeDuration; t += Time.unscaledDeltaTime)
        {
            float v = Mathf.Lerp(0f, 1f, t / fadeDuration);
            audioMixer.SetFloat(bgmVolumeParam, Mathf.Log10(Mathf.Max(v, 0.0001f)) * 20f);
            yield return null;
        }

        audioMixer.SetFloat(bgmVolumeParam, 0f); // 0 dB�� ����
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat(bgmVolumeParam, Mathf.Log10(Mathf.Clamp01(volume)) * 20f);
    }

    #endregion

    #region SFX

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        AudioSource source = GetAvailableSFXSource();
        source.clip = clip;
        source.volume = volume;
        source.Play();
        StartCoroutine(DisableWhenDone(source));
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(sfxVolumeParam, Mathf.Log10(Mathf.Clamp01(volume)) * 20f);
    }

    private AudioSource GetAvailableSFXSource()
    {
        foreach (var src in sfxSources)
        {
            if (!src.isPlaying){
                src.gameObject.SetActive(true);
                return src;
            }
        }

        var newSource = Instantiate(sfxSourcePrefab, transform);
        sfxSources.Add(newSource);
        return newSource;
    }

    private IEnumerator DisableWhenDone(AudioSource src, bool destroyAfterPlay = false)
    {
        yield return new WaitUntil(() => !src.isPlaying);

        src.clip = null;

        if (destroyAfterPlay)
        {
            sfxSources.Remove(src);
            Destroy(src.gameObject);
        }
           
        else
            src.gameObject.SetActive(false); // �Ǵ� Ǯ�� ��ȯ
    }

    #endregion
}
