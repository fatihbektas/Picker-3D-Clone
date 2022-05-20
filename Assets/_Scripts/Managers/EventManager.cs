public class EventManager : Singleton<EventManager>
{
    public delegate void EventHandler();

    public EventHandler OnContinue;
    public EventHandler OnFail;
    public EventHandler OnFinish;

    public EventHandler OnPlay;
    public EventHandler OnStop;
    public EventHandler OnWin;
}