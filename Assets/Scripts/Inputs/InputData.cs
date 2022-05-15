using UnityEngine;

[CreateAssetMenu(fileName = "Input Data", menuName = "ScriptableObjects/Input Data", order = 1)]
public class InputData : ScriptableObject
{
    public float moveSpeed;
    public float scaleValue;
    public float threshold;
}

