using UnityEngine;

public class InputManager : MonoBehaviour
{
    public const float ClampValue = 3.4f;
    [SerializeField] private InputData inputData;
    [SerializeField] private Camera camera;
    private float _deltaX, _firstXPos, _secondXPos;

    private void Update()
    {
        MoveForward();
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        if (Input.GetMouseButtonDown(0))
            _firstXPos = camera.ScreenToViewportPoint(Input.mousePosition).x -
                         transform.position.x / inputData.threshold;

        if (Input.GetMouseButton(0))
        {
            _secondXPos = camera.ScreenToViewportPoint(Input.mousePosition).x;
            _deltaX = (_secondXPos - _firstXPos) * inputData.threshold;

            var clampedDeltaX = Mathf.Clamp(_deltaX, -ClampValue, ClampValue);
            var playerTransform = transform;
            var position = playerTransform.position;
            position = new Vector3(clampedDeltaX, position.y, position.z);
            playerTransform.position = position;
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * inputData.moveSpeed));
    }
}