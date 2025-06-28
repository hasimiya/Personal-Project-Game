using UnityEngine;
public enum ArrowType
{
    Player,
    Enemy
}
public class DestroyOnHit : MonoBehaviour
{
    [SerializeField] private ArrowType arrowType;

    private GameManager gameManager;
    private UIManager uiManager;
    private SpawnManager spawnManager;
    private AudioManager audioManager;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        bool hitTarget = (tag == "Player" && arrowType == ArrowType.Enemy) || (tag == "Enemy" && arrowType == ArrowType.Player);

        if (hitTarget)
        {
            HandleTargetCollision(collision.gameObject, tag);
        }
        if (tag == "Arrow")
        {
            HandleArrowCollision(collision.gameObject);
        }
        if (tag == "Bound")
        {
            Destroy(gameObject);
        }
    }
    void HandleTargetCollision(GameObject enemyTarget, string tag)
    {
        if (tag == "Player")
        {
            uiManager.UpdateLives(-1);
            if (uiManager.lives != 0)
                audioManager.GetAudioSource(AudioClipType.AudioClipTypeEnum.Hitting);
        }
        if (tag == "Enemy")
        {
            if (enemyTarget != null)
            {
                enemyTarget.TryGetComponent<EnemyController>(out EnemyController enemy);
                if (enemy != null)
                {
                    Debug.Log("Enemy Destroy!");
                    audioManager.GetAudioSource(AudioClipType.AudioClipTypeEnum.Death);
                    Destroy(enemyTarget);
                    uiManager.UpdateCoinChest(enemy.pointValue);
                }
            }
        }
        Destroy(gameObject);
    }
    void HandleArrowCollision(GameObject other)
    {
        Destroy(gameObject);
        Destroy(other);
    }

}
