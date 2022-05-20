using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public void WinPanel()
    {
        Debug.Log("Win panel");
    }

    public void FailPanel()
    {
        Debug.Log("Fail panel");
    }
}