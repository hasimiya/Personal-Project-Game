using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public int score;
    public int lives;

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
}
