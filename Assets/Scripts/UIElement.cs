using System.Collections.Generic;

public abstract class UIElement<T> : Singleton<T> where T : UIElement<T>
{
    protected virtual UIState[] ValidStates { get; } = new UIState[] {};
    protected HashSet<UIState> ValidStatesLookup { get; private set; }
    private UIState PreviousState { get; set; } = UIState.None;

    protected override void Awake()
    {
        base.Awake();
        
        ValidStatesLookup = new HashSet<UIState>(ValidStates);
    }

    protected virtual void Start()
    {
        UIController.Instance.OnStateChange += HandleStateChange;
    }

    protected virtual void OnDestroy()
    {
        UIController.Instance.OnStateChange -= HandleStateChange;
    }

    private void ShowUI(bool state)
    {
        gameObject.SetActive(state);
    }

    protected virtual void HandleStateChange(UIState state)
    {
        if (ValidStatesLookup.Contains(state))
        {
            OnEnterValidState();
        }
        else
        {
            if (ValidStatesLookup.Contains(PreviousState))
            {
                OnExitValidState();
            }

            OnEnterInvalidState();
        }

        PreviousState = state;
    }

    protected virtual void OnEnterValidState()
    {
        ShowUI(true);
    }

    protected virtual void OnExitValidState()
    {

    }

    protected virtual void OnEnterInvalidState()
    {
        ShowUI(false);
    }
}
