using UnityEngine;

public class MouseLookInput : ILookInput
{
    private readonly float _mouseSensitivity;

    public MouseLookInput(float sensitivity)
    {
        _mouseSensitivity = sensitivity;
    }

    public Vector2 GetLookDelta()
    {
        return new Vector2(
            Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime,
            Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime
        );
    }
}
