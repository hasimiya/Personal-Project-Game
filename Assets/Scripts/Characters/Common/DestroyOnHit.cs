using UnityEngine;
public enum ArrowType
{
    Player,
    Enemy
}
public class DestroyOnHit : MonoBehaviour
{
    [SerializeField] private ArrowType arrowType;

    private UIManager uiManager;
    private AudioManager audioManager;
    private AnimationManager animationManager;

    private GameObject[] enemies;
    private void Start()
    {
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
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
    void HandleTargetCollision(GameObject enemyTarget, string tag) // ABSTRACTION
    {
        if (tag == "Player")
        {
            uiManager.UpdateLives(-1);
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
    void DestroyEnemy(GameObject[] collection) // ABSTRACTION
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
            }
        }
    }
    void IsTriggerCollider(GameObject enemyTarget) // ABSTRACTION
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
