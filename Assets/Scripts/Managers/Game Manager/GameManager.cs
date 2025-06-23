using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseSrceen;
    public Button restartGame;

    private SpawnManager spawnManager;

    private bool isPaused = false;
    private bool isGameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        StartGame();
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
    void StartGame()
    {
        isGameActive = true;
        spawnManager.SpawnPowerUp();
        spawnManager.SpawnEnemy(spawnManager.waveNumber);
    }
}
