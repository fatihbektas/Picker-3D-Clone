using System.Collections;
using DG.Tweening;
using UnityEngine;

public abstract class CollectableBase : MonoBehaviour
{
    private bool _isCollected;

    protected bool IsCollected { get; set; }

    protected void MoveOnZ(float stepValue, float duration)
    {
        transform.DOMoveZ(stepValue, duration).OnComplete(() => StartCoroutine(ShowBlowEffect()));
    }

    protected IEnumerator ShowBlowEffect()
    {
        print("Patlama efekti");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}