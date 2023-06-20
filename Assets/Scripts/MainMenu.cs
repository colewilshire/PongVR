using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu<MainMenu>
{
    [SerializeField] Button startGameButton;

    private void Start()
    {
        startGameButton.onClick.AddListener(GameManager.Instance.StartMatch);
    }

    private void OnDestroy()
    {
        startGameButton.onClick.RemoveListener(GameManager.Instance.StartMatch);
    }
}