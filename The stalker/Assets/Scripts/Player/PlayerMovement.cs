using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private float _stepHeight = 0.3f;
    [SerializeField] private float _fallMultiplier = 2f;

    [Header("Look Settings")]
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _cameraTransform;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;

    private IMovementInput _movementInput;
    private ILookInput _lookInput;
    private GravityHandler _gravityHandler;
    private MovementHandler _movementHandler;
    private JumpHandler _jumpHandler;
    private CameraRotationHandler _cameraRotationHandler;

    private void Awake()
    {
        _movementInput = new KeyboardMovementInput();
        _lookInput = new MouseLookInput(_mouseSensitivity);

        CharacterController controller = GetComponent<CharacterController>();

        _gravityHandler = new GravityHandler(
            controller, _groundCheck, _groundDistance, _groundMask, _gravity, _fallMultiplier);

        _movementHandler = new MovementHandler(
            controller, _moveSpeed, _stepHeight);

        _jumpHandler = new JumpHandler(
            _gravityHandler, _jumpHeight, _gravity);

        _cameraRotationHandler = new CameraRotationHandler(
            _cameraTransform, transform);
    }

    private void Update()
    {
        Vector2 lookDelta = _lookInput.GetLookDelta();
        _cameraRotationHandler.RotateCamera(lookDelta);

        _gravityHandler.UpdateGravity();

        Vector2 input = _movementInput.GetMovementInput();

        _movementHandler.Move(input, transform);

        if (_movementInput.IsJumpPressed())
            _jumpHandler.TryJump();
    }
}
