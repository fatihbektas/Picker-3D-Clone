using UnityEngine;

public class Cube : CollectableBase
{
    private void OnEnable()
    {
        CheckPointController.OnCheckPointReached += EmptyBasket;
    }

    private void OnDisable()
    {
        CheckPointController.OnCheckPointReached -= EmptyBasket;
    }

    private void OnTriggerStay(Collider other)
    {
        IsCollected = other.CompareTag("CollectArea");
    }

    private void EmptyBasket()
    {
        if (IsCollected) MoveOnZ(transform.position.z + 7, 1f);
    }
}