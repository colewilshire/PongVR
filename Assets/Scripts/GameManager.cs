using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private Controls controls;
    private InputAction pauseAction;
    private bool isPaused = false;
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

    private void Start()
    {
        OpenMainMenu();
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
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        PauseMenu.Instance.ShowUI(true);
        Time.timeScale = 0f;
    }

    private void ChangeScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.Instance.ShowUI(false);
        Time.timeScale = 1f;
    }

    public void StartMatch()
    {
        MainMenu.Instance.ShowUI(false);
        Scoreboard.Instance.ResetScore();
        ChangeScene(matchSceneName);
        Scoreboard.Instance.ShowUI(true);
    }

    public void EndMatch() //Controlled by score?
    {
        //Change scene
        //Show end game menu
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        ResumeGame();
        Scoreboard.Instance.ShowUI(false);
        ChangeScene(mainMenuSceneName);
        MainMenu.Instance.ShowUI(true);
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
