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

    private bool isPaused = false;
    public bool isGameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
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

        spawnManager.SpawnPowerUp();
        spawnManager.SpawnEnemy(spawnManager.waveNumber);

        titleScreen.gameObject.SetActive(false);
        uiScreen.gameObject.SetActive(true);

    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
    }
}
