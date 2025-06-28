using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    // UI variables
    public GameObject pauseSrceen;
    public GameObject titleScreen;
    public GameObject gameResultScreen;
    public GameObject uiScreen;

    public TextMeshProUGUI gameResultText;

    private SpawnManager spawnManager;
    private UIManager uiManager;
    private AudioManager audioManager;

    private bool isPaused = false;
    public bool isGameActive = false;

    public int waveNumber = 1;
    public int maxWave;

    public int remainingCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
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
            pauseSrceen.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            pauseSrceen.SetActive(true);
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
        uiManager.UpdateWave(waveNumber);

        player.SetActive(true);

        spawnManager.SpawnPowerUpPotion();
        spawnManager.SpawnEnemy(waveNumber);

        titleScreen.SetActive(false);
        uiScreen.SetActive(true);
    }
    public void WinGame()
    {
        isGameActive = false;
        uiScreen.SetActive(false);
        gameResultScreen.SetActive(true);

        gameResultText.text = $"You Win!\nScore: {uiManager.score}";
        gameResultText.color = Color.white;
        Debug.Log("You Win!");

        DestroyObjectsGameOver();
    }
    public void GameOver()
    {
        audioManager.GetAudioSource(AudioClipType.AudioClipTypeEnum.Death);
        isGameActive = false;
        uiScreen.SetActive(false);
        gameResultScreen.SetActive(true);
        gameResultText.text = $"Game Over!\nScore: {uiManager.score}";

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
    public void RegisterCoin()
    {
        remainingCoins++;
    }

    public void CollectCoin()
    {
        remainingCoins--;
        if (IsLastWave() && remainingCoins <= 0)
        {
            WinGame();
        }
    }

    public bool IsLastWave()
    {
        return waveNumber == maxWave;
    }
}
