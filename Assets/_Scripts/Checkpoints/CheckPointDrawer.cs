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
    private Collider _collider;
    private bool _isOpened;
    private bool _isTriggered;
    private Coroutine _coroutine;


    private void Start()
    {
        amountText.text = $"{currentAmount}/{maxAmount}";
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collectable")) CountObjects();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint") && !_isTriggered)
        {
            _isTriggered = true;
            EventManager.Instance.OnStop?.Invoke();
        }
    }

    public static event Action<Transform, int> OnCheckPointArrived;

    private void CountObjects()
    {
        currentAmount++;
        amountText.text = $"{currentAmount}/{maxAmount}";
        if (currentAmount >= maxAmount && _isOpened == false)
        {
            _isOpened = true;
            StartCoroutine(ContinueLevel());
            return;
        }


        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if (_collider.enabled == false)
        {
            return;
        }
        _coroutine = StartCoroutine(FailControl());
    }

    public IEnumerator FailControl()
    {
        yield return new WaitForSeconds(1f);
        _collider.enabled = false;
        GameManager.Instance.FailPanel();
    }



    private IEnumerator ContinueLevel()
    {
        OnCheckPointArrived?.Invoke(transform.parent.parent, sectionId);
        yield return new WaitForSeconds(1.5f);
        EventManager.Instance.OnContinue?.Invoke();
    }
}