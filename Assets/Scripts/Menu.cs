public abstract class Menu<T> : Singleton<T> where T : Menu<T>
{
    protected override void Awake()
    {
        base.Awake();
    
        ShowUI(false);
    }

    public virtual void ShowUI(bool state)
    {
        gameObject.SetActive(state);
    }
}