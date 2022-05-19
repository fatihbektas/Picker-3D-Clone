using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button playButton;
    
    private void Start()
    {
        EventManager.Instance.OnPlay += CloseButton;
    }
    
    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(PlayGame);
    }
    
    private static void PlayGame()
    {
        Debug.Log("PlayGame executed");
        EventManager.Instance.OnPlay?.Invoke();
    }
    
    private void CloseButton()
    {
        gameObject.SetActive(false);
    }
}