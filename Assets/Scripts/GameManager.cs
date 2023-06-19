using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuCanvas;
    private Controls controls;
    private float move;
    private InputAction pauseAction;
    private bool isPaused = false;
    private UIManager uiManager;

    private void Awake()
    {
        controls = new Controls();
        pauseAction = controls.Menu.Pause;
    }

    void OnEnable()
    {
        pauseAction.performed += OnPause;
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.performed -= OnPause;
        pauseAction.Disable();
    }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (isPaused)
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
        uiManager.OpenMenu("Pause Menu");
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        uiManager.CloseMenu();
        Time.timeScale = 1f;
    }
}
