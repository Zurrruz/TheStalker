using UnityEngine;

public class BotRotation
{
    private readonly Transform _transform;
    private readonly float _rotationSpeed;

    public BotRotation(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public void RotateTowards(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        _transform.rotation = Quaternion.Slerp(
            _transform.rotation,
            targetRotation,
            _rotationSpeed * Time.fixedDeltaTime
        );
    }
}
