using UnityEngine;

public class CameraRotationHandler
{
    private readonly Transform _cameraTransform;
    private readonly Transform _characterTransform;
    private readonly float _upperLookLimit;
    private readonly float _lowerLookLimit;

    private float _xRotation = 0f;

    public CameraRotationHandler(Transform cameraTransform, Transform characterTransform,
                               float upperLookLimit = 90f, float lowerLookLimit = -90f)
    {
        _cameraTransform = cameraTransform;
        _characterTransform = characterTransform;
        _upperLookLimit = upperLookLimit;
        _lowerLookLimit = lowerLookLimit;
    }

    public void RotateCamera(Vector2 lookInput)
    {
        _xRotation -= lookInput.y;
        _xRotation = Mathf.Clamp(_xRotation, _lowerLookLimit, _upperLookLimit);

        _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _characterTransform.Rotate(Vector3.up * lookInput.x);
    }
}
