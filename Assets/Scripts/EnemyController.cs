using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rbEnemy;
    private GameObject player;

    private EnemyType enemyType;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Player Destroy!");
        }
    }
}
