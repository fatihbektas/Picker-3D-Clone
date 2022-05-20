using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform finishTransform;

    public void CreatePlatform()
    {
        var level = Instantiate(platformPrefab, finishTransform);
        level.transform.localScale = Vector3.one;
    }
}