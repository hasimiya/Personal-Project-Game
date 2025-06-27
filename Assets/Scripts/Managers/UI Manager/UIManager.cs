using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI waveText;

    public int score;
    public int lives;

    // Timer variables
    public float currentTime;
    public float startTime = 5f;
    private bool timerRunning = true;

    private int coinChest;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }
    public void UpdateLives(int health)
    {
        lives += health;
        livesText.text = $"Lives: {lives}";
        if (lives <= 0)
        {
            gameManager.GameOver();
        }
    }
    public void UpdateWave(int waveNumber)
    {
        waveText.text = $"Wave: {waveNumber}";
    }
    public void UpdateCoinChest(int points)
    {
        coinChest += points;
    }
    public void OpenChest()
    {
        int totalCoins = coinChest;
        UpdateScore(totalCoins);
        coinChest = 0;
    }
    public IEnumerator SpawnWaveTimer()
    {
        currentTime = startTime;
        timerText.gameObject.SetActive(true);
        timerRunning = true;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            int displayTime = Mathf.RoundToInt(currentTime);
            displayTime = Mathf.Max(displayTime, 0);
            UpdateTimerUI(displayTime);
            yield return null;
        }
        timerText.gameObject.SetActive(false);
    }
    void UpdateTimerUI(int displayTime)
    {
        timerText.text = $"Wave spawn: {displayTime}";
    }
}
