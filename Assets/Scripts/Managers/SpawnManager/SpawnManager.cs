using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject powerUpPrefab;

    private float spawnRangeX = 23;
    private float spawnRangeZ = 8;
    private float spawnZ = 10;
    private float offsetY = 0.5f;

    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPowerUp();
        SpawnEnemy(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
            SpawnPowerUp();
        }
    }
    void SpawnEnemy(int waveNumber)
    {


        for (int i = 0; i < waveNumber; i++)
        {
            int indexPrefabs = Random.Range(1, enemyPrefabs.Length);
            float spawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);
            float spawnPositionZ = Random.Range(-spawnRangeZ, spawnRangeZ);

            Instantiate(enemyPrefabs[0], GenerateRandomSpawnPosition(spawnPositionX, spawnZ), enemyPrefabs[0].transform.rotation);

            Instantiate(enemyPrefabs[indexPrefabs], GenerateRandomSpawnPosition(spawnPositionX, spawnPositionZ), enemyPrefabs[indexPrefabs].transform.rotation);
            Instantiate(enemyPrefabs[indexPrefabs], GenerateRandomSpawnPosition(spawnPositionX, spawnPositionZ), enemyPrefabs[indexPrefabs].transform.rotation);

        }
    }
    void SpawnPowerUp()
    {
        float spawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPositionZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Instantiate(powerUpPrefab, GenerateRandomSpawnPosition(spawnPositionX, spawnPositionZ), powerUpPrefab.transform.rotation);
    }

    Vector3 GenerateRandomSpawnPosition(float x, float z)
    {
        return new Vector3(x, offsetY, z);
    }
}
