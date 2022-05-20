using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CheckPointDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private int maxAmount;
    [SerializeField] private int currentAmount;
    [SerializeField] private int sectionId;
    private bool isOpened;


    private void Start()
    {
        amountText.text = $"{currentAmount}/{maxAmount}";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collectable")) CountObjects();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint")) EventManager.Instance.OnStop?.Invoke();
    }

    public static event Action<Transform, int> OnCheckPointArrived;

    private void CountObjects()
    {
        currentAmount++;
        amountText.text = $"{currentAmount}/{maxAmount}";
        if (currentAmount >= maxAmount && isOpened == false)
        {
            isOpened = true;
            StartCoroutine(ContinueLevel());
        }

        //GameManager.Instance.FailPanel();
    }


    private IEnumerator ContinueLevel()
    {
        OnCheckPointArrived?.Invoke(transform.parent.parent, sectionId);
        yield return new WaitForSeconds(1.5f);
        EventManager.Instance.OnContinue?.Invoke();
    }
}