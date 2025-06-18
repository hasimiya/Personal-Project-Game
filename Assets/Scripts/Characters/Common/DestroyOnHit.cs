using UnityEngine;
public enum ArrowType
{
    Player,
    Enemy
}
public class DestroyOnHit : MonoBehaviour
{
    [SerializeField] private ArrowType arrowType;
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if ((tag == "Player" && arrowType == ArrowType.Enemy) || (tag == "Enemy" && arrowType == ArrowType.Player) || tag == "Arrow")
        {
            Debug.Log($"{tag} Destroy!");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (tag == "Bound")
        {
            Destroy(gameObject);
        }
    }
}
