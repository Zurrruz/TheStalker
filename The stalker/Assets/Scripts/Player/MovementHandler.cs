using UnityEngine;

public class MovementHandler
{
    private readonly CharacterController _controller;
    private readonly float _moveSpeed;

    public MovementHandler(CharacterController controller, float moveSpeed, float stepHeight)
    {
        _controller = controller;
        _moveSpeed = moveSpeed;
        _controller.stepOffset = stepHeight;
    }

    public void Move(Vector2 input, Transform transform)
    {
        Vector3 move = transform.right * input.x + transform.forward * input.y;
        _controller.Move(_moveSpeed * Time.deltaTime * move);
    }
}