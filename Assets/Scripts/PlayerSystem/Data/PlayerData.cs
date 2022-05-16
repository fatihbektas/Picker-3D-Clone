using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/Player Data", order = 1)]
public class PlayerData : ScriptableObject
{
    public float forwardSpeed;
    public float xSpeed;
}