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

    private int _score;
    public int score // ENCAPSULATION
    {
        get
        {
            return _score;
        }
        set
        {
            if (value < 0f)
            {
                Debug.LogError("Score cannot be negative!");
            }
            else
            {
                value = _score;
            }
        }
    }
    private int _lives;
    public int lives // ENCAPSULATION
    {
        get
        {
            return _lives;
        }
        set
        {
            if (value <= 0)
            {
                Debug.LogError("Lives cannot be negative!");
            }
            else
            {
                _lives = value;
            }
        }
    }

    // Timer variables
    private float currentTime;
    private float startTime = 5f;

    private int coinChest;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = $"Score: {_score}";
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
