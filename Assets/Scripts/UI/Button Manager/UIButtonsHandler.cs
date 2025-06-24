using UnityEngine;
using UnityEngine.UI;

public class UIButtonsHandler : MonoBehaviour
{
    public enum UIButtonAction
    {
        Start,
        Restart
    }
    public UIButtonAction buttonAction;
    private GameManager gameManager;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => HandleButtonAction(buttonAction));
    }
    void HandleButtonAction(UIButtonAction action)
    {
        switch (action)
        {
            case UIButtonAction.Start:
                gameManager.StartGame();
                break;
            case UIButtonAction.Restart:
                gameManager.RestartGame();
                break;
        }
    }
}
