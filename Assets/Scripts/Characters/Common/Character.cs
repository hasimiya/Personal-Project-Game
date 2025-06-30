using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody rbCharacter;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform projectileSpawnPoint;
    public AudioClip deathClip;
    public AudioClip hittingClip;
    public AudioClip shootingClip;
    public AudioClip powerUpClip;
    protected AudioManager audioManager;

    protected ParticleSystem deathParticleSystem;
    protected virtual void Awake()
    {
        rbCharacter = GetComponent<Rigidbody>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }
    protected virtual void Move(Vector3 direction)
    {
        if (direction != Vector3.zero) // Vector3.zero - это вектор, который указывает на отсутствие движения
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            // LookRotation - это метод, который создает кватернион поворота, который смотрит в направлении inputDirection
            // Vector3.up - это вектор, который указывает вверх, и используется для определения оси вращения
            // параметры метода LookRotation: 1 - направление, в котором нужно смотреть (inputDirection), 2 - вектор, который указывает вверх (Vector3.up)
            rbCharacter.MoveRotation(toRotation);
        }
        rbCharacter.velocity = direction.normalized * speed;
    }
    protected virtual void Fire(Vector3 direction)
    {
        Debug.Log("Fire!");
        audioManager.PlaySFX(AudioClipType.AudioClipTypeEnum.Shooting);
        Instantiate(projectilePrefab, projectileSpawnPoint.position, rbCharacter.rotation);
    }
    protected virtual void Fire2()
    {
        Debug.Log("Fire!");
        Quaternion shootRotation = Quaternion.LookRotation(Vector3.back);
        audioManager.PlaySFX(AudioClipType.AudioClipTypeEnum.Shooting);
        Instantiate(projectilePrefab, projectileSpawnPoint.transform.position, shootRotation);
    }
}
