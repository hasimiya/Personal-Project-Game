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

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
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
    void HandleTargetCollision(GameObject target, string tag)
    {
        if (tag == "Player")
        {
            gameManager.GameOver();
        }
        if (tag == "Enemy")
        {
            EnemyController enemy = target.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                uiManager.UpdateScore(enemy.pointValue);
                Debug.Log("Enemy Destroy!");
            }
        }
        Destroy(target);
        Destroy(gameObject);
    }
    void HandleArrowCollision(GameObject other)
    {
        Destroy(gameObject);
        Destroy(other);
    }
}
