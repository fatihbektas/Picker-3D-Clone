using DG.Tweening;
using UnityEngine;

public class PlanePiece : MonoBehaviour
{
    [SerializeField] private int sectionId;

    [SerializeField] private Animator leftGateAnimator;
    [SerializeField] private Animator rightGateAnimator;
    public Transform destinationCheckpoint;


    private void OnEnable()
    {
        CheckPointDrawer.OnCheckPointArrived += MovePlaneUp;
    }

    private void OnDisable()
    {
        CheckPointDrawer.OnCheckPointArrived -= MovePlaneUp;
    }

    private void MovePlaneUp(Transform transform)
    {
        if (transform.name == destinationCheckpoint.name)
            transform.GetChild(0).GetChild(5).DOLocalMoveY(3f, 1f).OnComplete(() =>
            {
                leftGateAnimator.enabled = true;
                rightGateAnimator.enabled = true;
            });
    }
}