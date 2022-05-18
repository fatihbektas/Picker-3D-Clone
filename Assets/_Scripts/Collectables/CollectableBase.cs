using System.Collections;
using DG.Tweening;
using UnityEngine;

public abstract class CollectableBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectArea")) EventManager.Instance.OnStop += MoveOnZ;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CollectArea")) EventManager.Instance.OnStop -= MoveOnZ;
    }

    protected void MoveOnZ()
    {
        transform.DOMoveZ(transform.position.z + 7f, 1f).OnComplete(() => StartCoroutine(ShowBlowEffect()));
    }

    private IEnumerator ShowBlowEffect()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}