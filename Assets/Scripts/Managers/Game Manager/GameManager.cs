using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI variables
    public GameObject pauseSrceen;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject uiScreen;

    private SpawnManager spawnManager;
    private UIManager uiManager;

    private bool isPaused = false;
    public bool isGameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        uiScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePaused();
        }
    }
    void ChangePaused()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            pauseSrceen.gameObject.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            pauseSrceen.gameObject.SetActive(true);
            isPaused = true;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        isGameActive = true;

        uiManager.score = 0;

        uiManager.scoreText.text = $"Score: {uiManager.score}";
        uiManager.UpdateLives(3);

        spawnManager.SpawnPowerUpPotion();
        spawnManager.SpawnEnemy(spawnManager.waveNumber);

        titleScreen.gameObject.SetActive(false);
        uiScreen.SetActive(true);

    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);

        Debug.Log("Game Over!");
        Debug.Log("Player Destroyed!");

        DestroyObjectsGameOver();
    }
    void DestroyObjectsGameOver()
    {
        Destroy(GameObject.Find("Player"));

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUp");
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        foreach (GameObject powerUp in powerUps)
        {
            Destroy(powerUp);
        }
        foreach (GameObject arrow in arrows)
        {
            Destroy(arrow);
        }
    }
}
