using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Controls controls;
    private float move;
    private InputAction pauseAction;
    [SerializeField] private UIManager uiManager;
    private bool isPaused = false;
    public static GameManager Instance { get; private set; } = null;

	private void Awake()
	{
		if (Instance == null)
        {
			Instance = this;
            DontDestroyOnLoad(gameObject);
        }
		else
		{
			Destroy(gameObject);
			return;
		}

        controls = new Controls();
        pauseAction = controls.Menu.Pause;
	}

    void OnEnable()
    {
        pauseAction.performed += OnPause;
        pauseAction.Enable();
    }

    // private void OnDisable()
    // {
    //     Debug.Log(pauseAction);
    //     pauseAction.performed -= OnPause;
    //     pauseAction.Disable();
    // }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        uiManager.OpenMenu("Main Menu");
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
        Time.timeScale = 0f;
        uiManager.OpenMenu("Pause Menu");
    }

    private void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }
    
    public void StartGame()
    {
        uiManager.CloseMenu();
        SceneManager.LoadScene("GameScene");
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        uiManager.CloseMenu();
    }

    public void EndGame(int winnerIndex)
    {
        ResetScene();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        ResumeGame();
        uiManager.OpenMenu("Main Menu");
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
