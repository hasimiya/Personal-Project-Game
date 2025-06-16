using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rbEnemy;
    private GameObject player;

    private Vector3 lookDirection;
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
        //lookDirection = (player.transform.position - transform.position).normalized;
        //rbEnemy.AddForce(lookDirection * speed);

        //switch (enemyType)
        //{
        //    case EnemyType.Goblin:
        //        lookDirection = (player.transform.position - transform.position).normalized;
        //        rbEnemy.AddForce(lookDirection * speed);
        //        break;
        //    case EnemyType.Skeleton:
        //        break;
        //    case EnemyType.Werewolf:

        //        break;
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (enemyType)
        {
            case EnemyType.Goblin:
                lookDirection = (player.transform.position - transform.position).normalized;
                rbEnemy.AddForce(lookDirection * speed);
                break;
            case EnemyType.Skeleton:
                break;
            case EnemyType.Werewolf:

                break;
        }
    }
}
