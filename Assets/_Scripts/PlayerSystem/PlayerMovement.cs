using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    [Range(1, 5000)] [SerializeField] private float threshHold;

    [SerializeField] private Camera camera;
    public bool isActive;
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
        if (!isActive) return;
        _rigidbody.velocity = Vector3.forward * playerData.speed;
    }

    private void MoveHorizontal()
    {
        if (!isActive) return;
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

    private void Activate()
    {
        print("1");
        isActive = true;
        _rigidbody.isKinematic = false;
    }

    private void Deactivate()
    {
        isActive = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
    }
}