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
    private ParticleManager particleManager;
    private AnimationManager animationManager;
    private GameObject[] enemies;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        particleManager = GameObject.Find("Particle Manager").GetComponent<ParticleManager>();
        animationManager = GameObject.Find("Animation Manager").GetComponent<AnimationManager>();
    }
    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
            //uiManager.UpdateLives(-1);
            //IsTriggerCollider(enemies);
            if (uiManager.lives != 0)
                audioManager.PlaySFX(AudioClipType.AudioClipTypeEnum.Hitting);
        }
        if (tag == "Enemy")
        {
            if (enemyTarget != null)
            {
                enemyTarget.TryGetComponent<EnemyController>(out EnemyController enemy);
                if (enemy != null)
                {
                    // Destroy
                    Debug.Log("Enemy Destroy!");
                    enemy.isAlive = false;
                    enemy.GetComponent<MoveForward>().StopMoving();
                    IsTriggerCollider(enemyTarget);

                    DestroyEnemy(enemies);

                    // Animation                    
                    animationManager.PlayAnimation(enemy.GetAnimator());

                    // Audio
                    audioManager.PlaySFX(AudioClipType.AudioClipTypeEnum.Death);

                    // UI
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
    void DestroyEnemy(GameObject[] collection)
    {
        bool allDead = true;
        foreach (GameObject enemy in collection)
        {
            if (enemy.TryGetComponent<EnemyController>(out EnemyController enemyController))
            {
                if (enemyController.isAlive)
                {
                    allDead = false;
                    break;
                }
            }
        }
        if (allDead)
        {
            foreach (GameObject enemy in collection)
            {
                Destroy(enemy, 1.5f);
                //TakePowerUp power = new TakePowerUp();
                //power.DestroyPowerUp(power.powerUpCollection);
            }
        }
    }
    void IsTriggerCollider(GameObject enemyTarget)
    {
        BoxCollider boxCollider = enemyTarget.GetComponent<BoxCollider>();
        Rigidbody rb = enemyTarget.GetComponent<Rigidbody>();
        if (boxCollider != null && rb != null)
        {
            boxCollider.isTrigger = true;
            rb.useGravity = false;
        }
        else
        {
            Debug.LogWarning("BoxCollider or Rigidbody not found on the enemy target.");
        }
    }
}
