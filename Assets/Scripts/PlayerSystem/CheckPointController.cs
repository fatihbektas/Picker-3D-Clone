using System;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = transform.parent.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("CheckPoint")) return;
        _playerMovement.Deactivate();
        OnCheckPointReached?.Invoke();
    }

    public static event Action OnCheckPointReached;
}