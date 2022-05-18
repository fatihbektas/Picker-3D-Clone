using System.Collections;
using TMPro;
using UnityEngine;

public class CheckPointDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private int maxAmount;
    [SerializeField] private int currentAmount;
    [SerializeField] private Animator leftGate;
    [SerializeField] private Animator rightGate;
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
        if (other.CompareTag("Player")) EventManager.Instance.OnStop?.Invoke();
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
        amountText.text = currentAmount + " / " + maxAmount;
    }

    private IEnumerator ContinueLevel()
    {
        leftGate.enabled = true;
        rightGate.enabled = true;
        yield return new WaitForSeconds(0.5f);
        EventManager.Instance.OnContinue?.Invoke();
    }
}