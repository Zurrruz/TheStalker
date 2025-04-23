using UnityEngine;

public class GravityHandler
{
    private readonly CharacterController _controller;
    private readonly Transform _groundCheck;
    private readonly LayerMask _groundMask;
    private readonly float _groundDistance;
    private readonly float _gravity;
    private readonly float _fallMultiplier;

    private Vector3 _velocity;  

    public GravityHandler(CharacterController controller, Transform groundCheck,
                        float groundDistance, LayerMask groundMask, 
                        float gravity,
                        float fallMultiplier)
    {
        _controller = controller;
        _groundCheck = groundCheck;
        _groundDistance = groundDistance;
        _groundMask = groundMask;
        _gravity = gravity;
        _fallMultiplier = fallMultiplier;
    }

    public bool IsGrounded { get; private set; }

    public void UpdateGravity()
    {
        IsGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (IsGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        _velocity.y += _gravity * (_velocity.y < 0 ? _fallMultiplier : 1f) * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void SetVerticalVelocity(float velocity) => _velocity.y = velocity;
}
