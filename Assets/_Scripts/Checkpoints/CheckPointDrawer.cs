using System.Collections;
using TMPro;
using UnityEngine;

public class CheckPointDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private int maxAmount;
    [SerializeField] private int currentAmount;
    [SerializeField] private Animator leftGateAnimator;
    [SerializeField] private Animator rightGateAnimator;
    private Collider _collider;

    private void Start()
    {
        ChangeText();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collectable")) CountObjects();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint")) EventManager.Instance.OnStop?.Invoke();
    }

    private void CountObjects()
    {
        currentAmount++;
        ChangeText();
        if (currentAmount >= maxAmount)
        {
            _collider.enabled = false;
            StartCoroutine(ContinueLevel());
        }
    }

    private void ChangeText()
    {
        amountText.text = $"{currentAmount}/{maxAmount}";
    }

    private IEnumerator ContinueLevel()
    {
        leftGateAnimator.enabled = true;
        rightGateAnimator.enabled = true;
        yield return new WaitForSeconds(0.5f);
        EventManager.Instance.OnContinue?.Invoke();
    }
}