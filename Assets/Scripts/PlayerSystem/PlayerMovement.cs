using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    [SerializeField] private PlayerData playerData;
    private float _distanceToScreen;
    private bool _isActive;
    private Vector3 _mousePos;

    private void Awake()
    {
        _isActive = true;
    }


    private void FixedUpdate()
    {
        if (!_isActive) return;

        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;

            _distanceToScreen = playerCamera.WorldToScreenPoint(gameObject.transform.position).z;
            _mousePos = playerCamera.ScreenToWorldPoint(
                new Vector3(mousePosition.x, mousePosition.y, _distanceToScreen));

            var direction = playerData.xSpeed;
            direction = _mousePos.x > transform.position.x ? direction : -direction;

            if (Mathf.Abs(_mousePos.x - transform.position.x) > .5f)
                transform.Translate(Time.deltaTime * direction, 0, 0);
        }

        transform.Translate(0, 0, Time.deltaTime * playerData.forwardSpeed);
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}