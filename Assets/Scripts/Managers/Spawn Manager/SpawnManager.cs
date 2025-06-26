using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] powerUpPrefabs;

    private float spawnRangeX = 23;
    private float spawnRangeZ = 8;
    private float spawnZ = 10;
    private float offsetY = 0.5f;

    public int enemyCount;
    public int waveNumber = 1;

    private bool isSpawningNextWave = false;

    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0 && gameManager.isGameActive == true && !isSpawningNextWave)
        {
            isSpawningNextWave = true;
            SpawnChestCoin();
            StartCoroutine(SpawnDelayWave());
        }
    }
    public void SpawnEnemy(int waveNumber)
    {
        for (int i = 0; i < waveNumber; i++)
        {
            int indexPrefabs = Random.Range(1, enemyPrefabs.Length);
            float spawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);

            Instantiate(enemyPrefabs[0], GenerateRandomSpawnPosition(spawnPositionX, spawnZ), enemyPrefabs[0].transform.rotation);

            Instantiate(enemyPrefabs[indexPrefabs], GenerateRandomSpawnPosition(), enemyPrefabs[indexPrefabs].transform.rotation);
            Instantiate(enemyPrefabs[indexPrefabs], GenerateRandomSpawnPosition(), enemyPrefabs[indexPrefabs].transform.rotation);
        }

    }
    public void SpawnPowerUpPotion()
    {
        float spawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPositionZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Instantiate(powerUpPrefabs[0], GenerateRandomSpawnPosition(spawnPositionX, offsetY, spawnPositionZ), powerUpPrefabs[0].transform.rotation);
    }
    public void SpawnPowerUpCoin(EnemyController enemy)
    {
        GameObject coin = Instantiate(powerUpPrefabs[1], enemy.transform.position, powerUpPrefabs[1].transform.rotation);
        TakePowerUp takePowerUp = coin.GetComponent<TakePowerUp>();
        takePowerUp.coinScore = enemy.pointValue;
    }
    public void SpawnChestCoin()
    {
        //GameObject coin = Instantiate(powerUpPrefabs[1], new Vector3(0, offsetY, 0), powerUpPrefabs[1].transform.rotation);
        //TakePowerUp takePowerUp = coin.GetComponent<TakePowerUp>();
        //takePowerUp.coinScore = ;

        Instantiate(powerUpPrefabs[1], new Vector3(0, offsetY, 0), powerUpPrefabs[1].transform.rotation);
    }
    Vector3 GenerateRandomSpawnPosition(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    Vector3 GenerateRandomSpawnPosition(float x, float z)
    {
        return new Vector3(x, 0, z);
    }
    Vector3 GenerateRandomSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPositionZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        return new Vector3(spawnPositionX, 0, spawnPositionZ);
    }
    IEnumerator SpawnDelayWave()
    {
        yield return new WaitForSeconds(5f);
        waveNumber++;
        SpawnEnemy(waveNumber);
        SpawnPowerUpPotion();
        isSpawningNextWave = false;
    }
}
