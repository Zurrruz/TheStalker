using UnityEngine;

public class JumpHandler
{
    private readonly GravityHandler _gravityHandler;
    private readonly float _jumpHeight;
    private readonly float _gravity;

    public JumpHandler(GravityHandler gravityHandler, float jumpHeight, float gravity)
    {
        _gravityHandler = gravityHandler;
        _jumpHeight = jumpHeight;
        _gravity = gravity;
    }

    public void TryJump()
    {
        if (_gravityHandler.IsGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            _gravityHandler.SetVerticalVelocity(jumpVelocity);
        }
    }
}
