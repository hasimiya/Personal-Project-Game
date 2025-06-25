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

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
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
        }
        if (tag == "Enemy")
        {
            EnemyController enemy = enemyTarget.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                Destroy(enemyTarget);
                Debug.Log("Enemy Destroy!");
                //spawnManager.SpawnPowerUpCoin(enemy);
                uiManager.UpdateScore(enemy.pointValue);
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
