using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            return;
        }

        Destroy(Instance);
        Instance = this as T;
    }
}