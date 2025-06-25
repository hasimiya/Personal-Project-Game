using UnityEngine;

public enum PowerUpType
{
    Coin,
    Potion
}
public class TakePowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public int coinScore;

    private UIManager uiManager;
    private void Start()
    {
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && uiManager.lives < 3 && powerUpType == PowerUpType.Potion)
        {
            Debug.Log($"PowerUp {powerUpType} Taken!");
            Destroy(gameObject);
            uiManager.UpdateLives(1);
        }
        if (other.gameObject.CompareTag("Player") && powerUpType == PowerUpType.Coin)
        {
            Debug.Log($"PowerUp {powerUpType} Taken!");
            uiManager.UpdateScore(coinScore);
            Destroy(gameObject);
        }
    }
}

