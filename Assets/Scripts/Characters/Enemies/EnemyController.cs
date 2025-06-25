using UnityEngine;

public class EnemyController : Character
{
    public EnemyType enemyType;
    private GameManager gameManager;
    private UIManager uiManager;

    public int pointValue;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();

        if (enemyType == EnemyType.Skeleton)
        {
            InvokeRepeating(nameof(Fire), 2f, 0.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiManager.UpdateLives(-1);
        }
    }
    void Fire()
    {
        Vector3 shootOffset = new Vector3(0, 1.5f, -0.8f);
        Vector3 spawnPosition = transform.position + shootOffset;
        Quaternion shootRotation = Quaternion.LookRotation(Vector3.back);
        Instantiate(projectilePrefab, spawnPosition, shootRotation);
    }
}
