using UnityEngine;

public enum PowerUpType
{
    Coin,
    Potion
}
public class TakePowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;

    private UIManager uiManager;
    private GameManager gameManager;
    private void Start()
    {
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
            uiManager.OpenChest();
            gameManager.CollectCoin();
            Destroy(gameObject);
        }
    }
}

