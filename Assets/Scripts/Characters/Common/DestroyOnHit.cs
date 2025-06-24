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
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        bool hitTarget = (tag == "Player" && arrowType == ArrowType.Enemy) || (tag == "Enemy" && arrowType == ArrowType.Player);
        if (hitTarget || tag == "Arrow")
        {
            Debug.Log($"{tag} Destroy!");
            Destroy(gameObject);
            Destroy(collision.gameObject);

            if (tag == "Player" && arrowType == ArrowType.Enemy)
            {
                gameManager.GameOver();
            }
        }
        if (tag == "Bound")
        {
            Destroy(gameObject);
        }
    }
}
