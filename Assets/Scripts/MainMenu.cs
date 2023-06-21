using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UIElement<MainMenu>
{
    [SerializeField] Button startGameButton;
    protected override UIState[] ValidStates { get; } =
    {
        UIState.MainMenu
    };

    protected override void Start()
    {
        base.Start();

        startGameButton.onClick.AddListener(GameManager.Instance.StartMatch);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        startGameButton.onClick.RemoveListener(GameManager.Instance.StartMatch);
    }
}