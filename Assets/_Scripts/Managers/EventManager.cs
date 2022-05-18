using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void EventHandler();

    public EventHandler OnContinue;
    public EventHandler OnFail;
    public EventHandler OnFinish;

    public EventHandler OnPlay;
    public EventHandler OnStop;
    public EventHandler OnWin;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) OnContinue?.Invoke();
        if (Input.GetKeyDown(KeyCode.F)) OnFail?.Invoke();
        if (Input.GetKeyDown(KeyCode.E)) OnFinish?.Invoke();
        if (Input.GetKeyDown(KeyCode.P)) OnPlay?.Invoke();
        if (Input.GetKeyDown(KeyCode.S)) OnStop?.Invoke();
        if (Input.GetKeyDown(KeyCode.W)) OnWin?.Invoke();
    }
}