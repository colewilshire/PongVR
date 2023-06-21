using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private Controls controls;
    private InputAction pauseAction;
    private string mainMenuSceneName = "MainMenuScene";
    private string matchSceneName = "MatchScene";

    protected override void Awake()
    {
        base.Awake();

        SetUpInputs();
    }

    private void OnDestroy()
    {
        DisableInputs();
    }

    private void SetUpInputs()
    {
        controls = new Controls();
        pauseAction = controls.Menu.Pause;
        pauseAction.performed += OnPause;

        pauseAction.Enable();
    }

    private void DisableInputs()
    {
        pauseAction.performed -= OnPause;

        pauseAction.Disable();
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        if (UIController.Instance.CurrentState == UIState.Pause)
        {
            UIController.Instance.SetState(UIState.MatchInProgress);
        }
        else if (UIController.Instance.CurrentState == UIState.MatchInProgress)
        {
            UIController.Instance.SetState(UIState.Pause);
        }
    }

    private void SetScene(string sceneName, UIState? state)
    {
        SceneManager.LoadScene(sceneName);

        if (state.HasValue)
        {
            UIController.Instance.SetState(state.Value);
        }
    }

    public void StartMatch()
    {
        SetScene(matchSceneName, UIState.MatchInProgress);
    }

    public void ResumeMatch()
    {
        UIController.Instance.SetState(UIState.MatchInProgress);
    }

    public void EndMatch()
    {
        UIController.Instance.SetState(UIState.MatchEnded);
    }

    public void ReturnToMainMenu()
    {
        SetScene(mainMenuSceneName, UIState.MainMenu);
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
