using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform finishTransform;

    public void CreatePlatform()
    {
        Instantiate(platformPrefab, finishTransform);
    }
}