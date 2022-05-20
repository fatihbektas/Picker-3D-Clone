using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] private List<GameObject> checkPoints = new();
    private int _checkPointId;

    private void Start()
    {
    }
}