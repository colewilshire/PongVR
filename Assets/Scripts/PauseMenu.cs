using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : UIElement<PauseMenu>
{

    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button exitGameButton;
    protected override UIState[] ValidStates { get; } =
    {
        UIState.Pause
    };

    protected override void Start()
    {
        base.Start();

        resumeButton.onClick.AddListener(GameManager.Instance.ResumeMatch);
        mainMenuButton.onClick.AddListener(GameManager.Instance.ReturnToMainMenu);
        exitGameButton.onClick.AddListener(GameManager.Instance.ExitToDesktop);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        resumeButton.onClick.RemoveListener(GameManager.Instance.ResumeMatch);
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