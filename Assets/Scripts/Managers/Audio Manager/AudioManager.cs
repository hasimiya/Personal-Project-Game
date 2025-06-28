using System.Collections.Generic;
using UnityEngine;
using static AudioClipType;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    private AudioClipType audioClipType;
    private Dictionary<AudioClipTypeEnum, AudioClip> clipMap;
    // Start is called before the first frame update
    void Start()
    {
        //var test = GameObject.Find("SFX Test");
        //if (test is null)
        //    throw new ArgumentNullException("something went wrong");
        //var a = test.GetComponent<AudioSource>();
        sfxSource = GameObject.Find("SFX Source").GetComponent<AudioSource>();
        audioClipType = GameObject.Find("SFX Source").GetComponent<AudioClipType>();
        musicSource = GameObject.Find("Music Source").GetComponent<AudioSource>();

        clipMap = new Dictionary<AudioClipTypeEnum, AudioClip>
        {
            { AudioClipTypeEnum.Death, audioClipType.deathClip},
            { AudioClipTypeEnum.Hitting, audioClipType.hittingClip},
            { AudioClipTypeEnum.Shooting, audioClipType.shootingClip},
            { AudioClipTypeEnum.PowerUp, audioClipType.powerUpClip}
        };
    }

    public void GetAudioSource(AudioClipTypeEnum clipType)
    {
        if (clipMap.TryGetValue(clipType, out AudioClip clip) && clip != null)
        // clipMap.TryGetValue - попытка получить значение из словаря по ключу clipType
        // параметры TryGetValue: 1 - ключ (clipType), 2 - значение (clip)
        {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
        else
        {
            Debug.LogWarning($"Audio clip not found for {clipType}");
        }

        //switch (clip)
        //{
        //    case AudioClipTypeEnum.Death:
        //        sfxSource.clip = audioClipType.deathClip;
        //        break;
        //    case AudioClipTypeEnum.Hitting:
        //        sfxSource.clip = audioClipType.hittingClip;
        //        break;
        //    case AudioClipTypeEnum.Shooting:
        //        sfxSource.clip = audioClipType.shootingClip;
        //        break;
        //    case AudioClipTypeEnum.PowerUp:
        //        sfxSource.clip = audioClipType.powerUpClip;
        //        break;
        //    default:
        //        //Debug.LogWarning("Audio clip not found for " + clip + " on " + other.name);
        //        Debug.LogWarning("Audio clip not found for " + clip + " on ");
        //        return;
        //}

        //if (sfxSource.clip != null)
        //{
        //    sfxSource.Play();
        //}
        //else
        //{
        //    //Debug.LogWarning("AudioSource is not assigned on " + other.name);
        //    Debug.LogWarning("AudioSource is not assigned on ");
        //}
    }
}
