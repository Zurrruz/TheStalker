using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BotController : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] private Transform _playerTarget;    

    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _stoppingDistance = 2f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _stepHeight = 0.3f;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundDistance = 0.4f;

    private BotLocomotion _locomotion;
    private BotRotation _rotation;

    private PlayerTargetProvider _playerTargetProvider;

    private void Awake()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;

        _locomotion = new BotLocomotion(
            rigidbody, _moveSpeed, _stepHeight,
            _groundCheck, _groundDistance, _groundMask
        );

        _playerTargetProvider = new PlayerTargetProvider(_playerTarget);
        _rotation = new BotRotation(transform, _rotationSpeed);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_playerTargetProvider.HasTarget() == false) return;

        Transform target = _playerTargetProvider.GetTarget();
        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        _rotation.RotateTowards(direction);

        float distance = direction.magnitude;

        if (distance > _stoppingDistance && _locomotion.IsGrounded())
            _locomotion.Move(direction);
        else
            _locomotion.Stop();

        _locomotion.HandleSteps();
    }
}
