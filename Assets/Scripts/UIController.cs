public class UIController : Singleton<UIController>
{
    private UIState defaultState = UIState.MainMenu;
    public delegate void OnStateChangeHandler(UIState state);
    public event OnStateChangeHandler OnStateChange;
    public UIState CurrentState { get; private set; }

    private void Start()
    {
        SetState(defaultState);
    }

    public void SetState(UIState state)
    {
        CurrentState = state;

        OnStateChange?.Invoke(state);
    }
}
