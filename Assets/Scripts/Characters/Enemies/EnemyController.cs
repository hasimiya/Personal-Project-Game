using UnityEngine;

public class EnemyController : Character
{
    public EnemyType enemyType;

    void Start()
    {
        if (enemyType == EnemyType.Skeleton)
        {
            InvokeRepeating(nameof(Fire), 2f, 0.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Player Destroy!");
        }
    }
    void Fire()
    {
        Vector3 shootOffset = new Vector3(0, 0, -0.8f);
        Vector3 spawnPosition = transform.position + shootOffset;
        Quaternion shootRotation = Quaternion.LookRotation(Vector3.back);
        Instantiate(projectilePrefab, spawnPosition, shootRotation);
    }
}
