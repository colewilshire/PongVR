using UnityEngine;
using UnityEngine.UI;

public class ResultsMenu : UIElement<ResultsMenu>
{
    [SerializeField] Button rematchButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button exitGameButton;
    protected override UIState[] ValidStates { get; } =
    {
        UIState.MatchEnded
    };

    protected override void Start()
    {
        base.Start();

        rematchButton.onClick.AddListener(GameManager.Instance.StartMatch);
        mainMenuButton.onClick.AddListener(GameManager.Instance.ReturnToMainMenu);
        exitGameButton.onClick.AddListener(GameManager.Instance.ExitToDesktop);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        rematchButton.onClick.RemoveListener(GameManager.Instance.StartMatch);
        mainMenuButton.onClick.RemoveListener(GameManager.Instance.ReturnToMainMenu);
        exitGameButton.onClick.RemoveListener(GameManager.Instance.ExitToDesktop);
    }

    protected override void OnEnterValidState()
    {
        base.OnEnterValidState();

        Time.timeScale = 0f;
    }

    protected override void OnExitValidState()
    {
        base.OnExitValidState();

        Time.timeScale = 1f;
    }
}