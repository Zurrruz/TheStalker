using UnityEngine;

public class BotLocomotion
{
    private readonly Rigidbody _rigidbody;
    private readonly Transform _groundCheck;
    private readonly LayerMask _groundMask;

    private readonly float _moveSpeed;
    private readonly float _stepHeight;
    private readonly float _groundDistance;

    public BotLocomotion(Rigidbody rigidbody, float moveSpeed, float stepHeight,
                        Transform groundCheck, float groundDistance, LayerMask groundMask)
    {
        _rigidbody = rigidbody;
        _moveSpeed = moveSpeed;
        _stepHeight = stepHeight;
        _groundCheck = groundCheck;
        _groundDistance = groundDistance;
        _groundMask = groundMask;
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
    }

    public void Move(Vector3 direction)
    {
        Vector3 moveDirection = direction.normalized * _moveSpeed;
        _rigidbody.velocity = new Vector3(moveDirection.x, _rigidbody.velocity.y, moveDirection.z);
    }

    public void Stop()
    {
        _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
    }

    public void HandleSteps()
    {
        if (Physics.Raycast(_rigidbody.position + Vector3.up * 0.2f, _rigidbody.transform.forward,
            out RaycastHit hit, 0.5f))
        {
            if (hit.collider != null && hit.distance < 0.5f &&
                hit.point.y - _rigidbody.position.y <= _stepHeight)
            {
                _rigidbody.position += _stepHeight * 0.1f * Vector3.up;
            }
        }
    }
}
