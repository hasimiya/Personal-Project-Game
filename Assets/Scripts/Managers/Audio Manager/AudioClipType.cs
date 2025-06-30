using UnityEngine;

public class AudioClipType : MonoBehaviour
{
    public enum AudioClipTypeEnum
    {
        None,
        Death,
        Hitting,
        Jumping,
        Landing,
        Shooting,
        Reloading,
        Running,
        Walking,
        Idle,
        Explosion,
        PowerUp,
        BackgroundMusic,
        GameOver,
        Victory
    }

    public AudioClip noneClip;
    public AudioClip deathClip;
    public AudioClip hittingClip;
    public AudioClip jumpingClip;
    public AudioClip landingClip;
    public AudioClip shootingClip;
    public AudioClip reloadingClip;
    public AudioClip runningClip;
    public AudioClip walkingClip;
    public AudioClip idleClip;
    public AudioClip explosionClip;
    public AudioClip powerUpClip;
    public AudioClip backgroundMusicClip;
    public AudioClip gameOverClip;
    public AudioClip victoryClip;
}