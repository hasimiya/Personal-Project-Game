using UnityEngine;

public class EnemyController : Character // INHERITANCE Child Class
{
    public EnemyType enemyType;
    private GameManager gameManager;
    private UIManager uiManager;
    [SerializeField] private Animator animator;
    public int pointValue;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();

        if (enemyType == EnemyType.Skeleton)
        {
            InvokeRepeating(nameof(Fire), 2f, 0.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiManager.UpdateLives(-1);
            if (uiManager.lives != 0)
                audioManager.PlaySFX(AudioClipType.AudioClipTypeEnum.Hitting);
        }
    }
    public Animator GetAnimator()
    {
        return animator;
    }
}
