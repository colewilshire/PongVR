using UnityEngine;
using UnityEngine.UI;

public class MatchEndMenu : Menu<MatchEndMenu>
{
    [SerializeField] Button rematchButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button exitGameButton;

    private void Start()
    {
        rematchButton.onClick.AddListener(GameManager.Instance.EndMatch);
        mainMenuButton.onClick.AddListener(GameManager.Instance.OpenMainMenu);
        exitGameButton.onClick.AddListener(GameManager.Instance.ExitToDesktop);
    }

    private void OnDestroy()
    {
        rematchButton.onClick.RemoveListener(GameManager.Instance.EndMatch);
        mainMenuButton.onClick.RemoveListener(GameManager.Instance.OpenMainMenu);
        exitGameButton.onClick.RemoveListener(GameManager.Instance.ExitToDesktop);
    }
}