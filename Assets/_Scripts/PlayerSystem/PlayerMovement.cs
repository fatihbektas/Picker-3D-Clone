using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    [Range(1, 5000)] [SerializeField] private float threshHold;

    [SerializeField] private Camera camera;
    public bool _isActive;
    private float _deltaX, _firstXPos, _secondXPos;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Deactivate();
    }

    private void Start()
    {
        EventManager.Instance.OnPlay += Activate;
        EventManager.Instance.OnStop += Deactivate;
        EventManager.Instance.OnContinue += Activate;
        EventManager.Instance.OnFail += Deactivate;
    }

    private void Update()
    {
        InputGetPos();
    }

    private void FixedUpdate()
    {
        MoveForward();
        MoveHorizontal();
    }

    private void MoveForward()
    {
        if (!_isActive) return;
        _rigidbody.velocity = Vector3.forward * playerData.speed;
    }

    private void MoveHorizontal()
    {
        _rigidbody.AddForce(Vector3.right * _deltaX, ForceMode.VelocityChange);
        _firstXPos = _secondXPos;
    }

    private void InputGetPos()
    {
        if (Input.GetMouseButtonDown(0))
            _firstXPos = camera.ScreenToViewportPoint(Input.mousePosition).x - transform.position.x / threshHold;

        if (Input.GetMouseButton(0))
        {
            _secondXPos = camera.ScreenToViewportPoint(Input.mousePosition).x;
            _deltaX = (_secondXPos - _firstXPos) * threshHold;
        }
    }

    public void Activate()
    {
        Debug.Log("Player has activated");
        _isActive = true;
    }

    public void Deactivate()
    {
        _rigidbody.velocity = Vector3.zero;
        Debug.Log("Player has stopped");
        _isActive = false;
    }
}