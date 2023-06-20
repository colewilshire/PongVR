using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : Menu<PauseMenu>
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button exitGameButton;

    private void Start()
    {
        resumeButton.onClick.AddListener(GameManager.Instance.ResumeGame);
        mainMenuButton.onClick.AddListener(GameManager.Instance.OpenMainMenu);
        exitGameButton.onClick.AddListener(GameManager.Instance.ExitToDesktop);
    }

    private void OnDestroy()
    {
        resumeButton.onClick.RemoveListener(GameManager.Instance.ResumeGame);
        mainMenuButton.onClick.RemoveListener(GameManager.Instance.OpenMainMenu);
        exitGameButton.onClick.RemoveListener(GameManager.Instance.ExitToDesktop);
    }
}