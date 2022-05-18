using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayGame);
        EventManager.Instance.OnPlay += CloseButton;
    }

    private void PlayGame()
    {
        EventManager.Instance.OnPlay?.Invoke();
    }

    public void CloseButton()
    {
        gameObject.SetActive(false);
    }
}