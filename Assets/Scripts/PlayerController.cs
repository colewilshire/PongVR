using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public int playerIndex = 0;
    private float movementSpeed = 5f;
    private float maxZOffset = 100f;//1f;
    private Rigidbody rb;
    private Vector3 startPosition;
    private Controls controls;
    private float move;
    private InputAction moveAction;

    private void Awake()
    {
        controls = new Controls();
        moveAction = controls.Player.Move;
    }

    void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMoveEnd;
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMoveEnd;
        moveAction.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(move * movementSpeed, 0f, 0f);
        Vector3 newPosition = transform.position + movement * Time.deltaTime;

        newPosition.z = Mathf.Clamp(newPosition.z, startPosition.z - maxZOffset, startPosition.z + maxZOffset);
        rb.MovePosition(newPosition);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<float>();
    }

    private void OnMoveEnd(InputAction.CallbackContext context)
    {
        move = 0;
    }
}