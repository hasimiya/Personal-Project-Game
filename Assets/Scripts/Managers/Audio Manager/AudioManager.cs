using System.Collections.Generic;
using UnityEngine;
using static AudioClipType;

public class AudioManager : MonoBehaviour
{
    private AudioSource musicSource;
    private AudioClipType audioClipType;
    private AudioSource[] sfxSources;

    private Dictionary<AudioClipTypeEnum, AudioClip> clipMap;

    public float sfxVolume;

    // Start is called before the first frame update
    void Start()
    {

        musicSource = GameObject.Find("Music Source").GetComponent<AudioSource>();
        audioClipType = GameObject.Find("Audio Manager").GetComponent<AudioClipType>();
        clipMap = new Dictionary<AudioClipTypeEnum, AudioClip>
        {
            { AudioClipTypeEnum.Death, audioClipType.deathClip},
            { AudioClipTypeEnum.Hitting, audioClipType.hittingClip},
            { AudioClipTypeEnum.Jumping, audioClipType.jumpingClip},
            { AudioClipTypeEnum.Landing, audioClipType.landingClip},
            { AudioClipTypeEnum.Shooting, audioClipType.shootingClip},
            { AudioClipTypeEnum.Reloading, audioClipType.reloadingClip},
            { AudioClipTypeEnum.Running, audioClipType.runningClip},
            { AudioClipTypeEnum.Walking, audioClipType.walkingClip},
            { AudioClipTypeEnum.Idle, audioClipType.idleClip},
            { AudioClipTypeEnum.Explosion, audioClipType.explosionClip},
            { AudioClipTypeEnum.PowerUp, audioClipType.powerUpClip},
            { AudioClipTypeEnum.BackgroundMusic, audioClipType.backgroundMusicClip},
            { AudioClipTypeEnum.GameOver, audioClipType.gameOverClip},
            { AudioClipTypeEnum.Victory, audioClipType.victoryClip}
        };
        sfxSources = new AudioSource[5];
        for (int i = 0; i < sfxSources.Length; i++)
        {
            sfxSources[i] = gameObject.AddComponent<AudioSource>();
            sfxSources[i].playOnAwake = false;
            sfxSources[i].volume = sfxVolume;
        }
    }

    public void PlaySFX(AudioClipTypeEnum clipType)
    {

        if (clipMap.TryGetValue(clipType, out AudioClip clip) && clip != null)
        {
            foreach (var source in sfxSources)
            {
                if (!source.isPlaying)
                {
                    source.clip = clip;
                    source.Play();
                    return;
                }
            }
            sfxSources[0].clip = clip;
            sfxSources[0].Play();
        }
        else
        {
            Debug.LogWarning($"Audio clip not found for {clipType}");
        }
    }
    public void PlayGameStateMusic(AudioClipTypeEnum clipType)
    {
        if (clipMap.TryGetValue(clipType, out AudioClip clip) && clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = false;
            musicSource.Play();
        }
    }
}
