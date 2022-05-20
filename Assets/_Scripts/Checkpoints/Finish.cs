using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectArea"))
        {
            Debug.Log("VAR");
            PlatformManager.Instance.CreatePlatform();
        }
    }
}