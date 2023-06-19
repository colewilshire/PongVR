using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button exitGameButton;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        resumeButton.onClick.AddListener(gameManager.ResumeGame);
        mainMenuButton.onClick.AddListener(gameManager.ExitToMainMenu);
        exitGameButton.onClick.AddListener(gameManager.ExitToDesktop);
    }
}
